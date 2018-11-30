using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Feedz.Client.Logging;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace Feedz.Client
{
    public class Packages
    {
        private readonly FeedzClient _client;
        private readonly string _feedRootUri;
        private readonly string _rootUri;

        internal Packages(RepositoryScope scope, FeedzClient client)
        {
            _client = client;
            _rootUri = $"{scope.RootUri}/packages";
            _feedRootUri = $"{scope.OrganisationScope.Slug}/{scope.Slug}";
        }


        public async Task<FeedPackageResult> Upload(string filePath, bool replace = false, string region = null)
        {
            using (var stream = File.OpenRead(filePath))
                return await Upload(stream, Path.GetFileName(filePath), replace, region);
        }

        public async Task<FeedPackageResult> Upload(Stream stream, string originalFilename, bool replace = false, string region = null)
        {
            var sw = Stopwatch.StartNew();

            var result = await AttemptDeltaPush(stream, originalFilename, replace, region);
            if (result == null)
            {
                _client.Log.Info("Falling back to pushing the full package");
                stream.Seek(0, SeekOrigin.Begin);
                result = await _client.FeedClientWrapper.Create<FeedPackageResult>(
                    UrlTemplate.Resolve(_feedRootUri + "{?replace,region}", new {replace, region}),
                    stream,
                    originalFilename,
                    new Dictionary<string, string>()
                );
            }

            _client.Log.Info($"Package pushed in {sw.ElapsedMilliseconds:n0}ms");
            return result;
        }

        private async Task<FeedPackageResult> AttemptDeltaPush(Stream stream, string originalFilename, bool replace, string region)
        {
            var (packageId, version) = PackageIdAndVersionParser.Parse(Path.GetFileNameWithoutExtension(originalFilename));

            try
            {
                _client.Log.Info($"Requesting signature for delta compression from the server for upload of a package '{packageId}' version '{version}'");

                var signature = await _client.FeedClientWrapper.Get<PackageDeltaSignatureResult>(
                    UrlTemplate.Resolve(
                        _feedRootUri + "/delta-signature/{packageId}/{version}",
                        new {packageId, version}
                    )
                );

                var tempFile = Path.GetTempFileName();
                try
                {
                    var shouldUpload = DeltaCompression.CreateDelta(_client.Log, stream, signature, tempFile);
                    if (!shouldUpload)
                        return null;

                    using (var delta = File.OpenRead(tempFile))
                    {
                        var result = await _client.FeedClientWrapper.Create<FeedPackageResult>(
                            UrlTemplate.Resolve(
                                _feedRootUri + "/delta/{packageId}/{baseVersion}{?replace,region}",
                                new {packageId, baseVersion = signature.BaseVersion, replace, region}
                            ),
                            delta,
                            originalFilename,
                            new Dictionary<string, string>()
                        );

                        _client.Log.Info($"Delta transfer completed");
                        return result;
                    }
                }
                finally
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch
                    {
                    }
                }
            }
            catch (FeedzHttpRequestException hre) when (hre.Code == HttpStatusCode.NotFound)
            {
                _client.Log.Info("No package with the same ID exists on the server");
                return null;
            }
            catch (FeedzHttpRequestException hre) when (hre.Code == HttpStatusCode.Conflict)
            {
                throw new Exception("The package already exists");
            }
            catch (Exception)
            {
                _client.Log.Info("An error occured calculating the package delta");
                return null;
            }
        }

        public Task<FeedPackageResult> Get(string packageId, string version)
            => _client.FeedClientWrapper.Get<FeedPackageResult>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}", new {packageId, version})
            );
        
        public Task<FeedPackageResult> GetLatest(string packageId, bool includePreRelease = false)
            => _client.FeedClientWrapper.Get<FeedPackageResult>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/latest{?includePreRelease}", new {packageId, includePreRelease})
            );

        public Task<IReadOnlyList<FeedPackageResult>> All()
            => _client.FeedClientWrapper.List<FeedPackageResult>(
                $"{_feedRootUri}/packages"
            );

        public Task<IReadOnlyList<FeedPackageResult>> ListByPackageId(string packageId)
            => _client.FeedClientWrapper.List<FeedPackageResult>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}", new {packageId})
            );

        public Task<IReadOnlyList<PackageHeaderResource>> List(Guid[] ids = null, string[] packageIds = null)
            => _client.ApiClientWrapper.List<PackageHeaderResource>(
                UrlTemplate.Resolve(_rootUri + "{?packageIds,ids}", new {ids, packageIds})
            );

        public Task<Stream> Download(FeedPackageResult package, string similarPackagePath = null)
            => Download(package.PackageId, package.Version, similarPackagePath);

        public Task<Stream> Download(PackageHeaderResource package, string similarPackagePath = null)
            => Download(package.PackageId, package.Version, similarPackagePath);

        public async Task<Stream> Download(string packageId, string version, string similarPackagePath = null)
        {
            if (similarPackagePath != null)
            {
                _client.Log.Info("Attempting delta compression download");
                if (File.Exists(similarPackagePath))
                {
                    _client.Log.Info($"Using {similarPackagePath} as the base file");
                    using (var f = File.OpenRead(similarPackagePath))
                    {
                        var result = await AttemptDeltaDownload(packageId, version, f);
                        if (result != null)
                            return result;
                    }
                }
                else if (Directory.Exists(similarPackagePath))
                {
                    var file = Directory.GetFiles(similarPackagePath, packageId + "*.*")
                        .Select(f =>
                        {
                            try
                            {
                                return new
                                {
                                    File = f,
                                    Version = PackageIdAndVersionParser.Parse(Path.GetFileName(f)).version
                                };
                            }
                            catch
                            {
                                return null;
                            }
                        })
                        .Where(v => v != null)
                        .OrderByDescending(v => v.Version)
                        .FirstOrDefault();

                    if (file == null)
                    {
                        _client.Log.Info("Could not find a candidate file to base the delta on");
                    }
                    else
                    {
                        _client.Log.Info($"Using {file.File} as the base file");
                        using (var f = File.OpenRead(file.File))
                        {
                            var result = await AttemptDeltaDownload(packageId, version, f);
                            if (result != null)
                                return result;
                        }
                    }
                }
            }

            _client.Log.Info($"Downloading the full {packageId} {version} package");

            return await _client.FeedClientWrapper.Get<Stream>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}/download", new {packageId, version})
            );
        }

        private async Task<Stream> AttemptDeltaDownload(string packageId, string version, FileStream basisStream)
        {
            try
            {
                var builder = new SignatureBuilder();
                using (var signatureStream = new MemoryStream())
                {
                    builder.Build(basisStream, new SignatureWriter(signatureStream));

                    signatureStream.Seek(0, SeekOrigin.Begin);
                    basisStream.Seek(0, SeekOrigin.Begin);

                    using (var delta = await _client.FeedClientWrapper.Create<Stream>(
                        UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}/download-delta", new {packageId, version}),
                        signatureStream,
                        "delta",
                        new Dictionary<string, string>()
                    ))
                    {
                        var tempFile = Path.GetTempFileName();
                        Stream fs = null;
                        try
                        {
                            var deltaApplier = new DeltaApplier {SkipHashCheck = false};
                            fs = new TemporaryFileStream(tempFile, File.Open(tempFile, FileMode.OpenOrCreate, FileAccess.ReadWrite));
                            deltaApplier.Apply(basisStream, new BinaryDeltaReader(delta, new NullProgressReporter()), fs);
                            return fs;
                        }
                        catch
                        {
                            fs?.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _client.Log.Info("Failed delta download: " + ex.Message);
                return null;
            }
        }

        public Task Delete(FeedPackageResult package)
            => Delete(package.PackageId, package.Version);

        public Task Delete(PackageHeaderResource package)
            => Delete(package.PackageId, package.Version);

        public Task Delete(string packageId, string version)
            => _client.FeedClientWrapper.Remove(UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}", new {packageId, version}));
    }
}