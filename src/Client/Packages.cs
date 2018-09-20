using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Packages
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly string _rootUri;

        internal Packages(RepositoryScope scope, IHttpClientWrapper httpClientWrapper)
        {
            _rootUri = $"{scope.RootUri}/packages";
            _httpClientWrapper = httpClientWrapper;
        }

        public Task<PackageHeaderResource> Upload(Stream stream, string originalFilename, bool force = false, string region = null)
        {
            var formValues = new Dictionary<string, string>
            {
                {"force", force.ToString()},
                {"region", region}
            };
            return _httpClientWrapper.Create<PackageHeaderResource>($"{_rootUri}/upload", stream, originalFilename, formValues);
        }

        public Task<IReadOnlyList<PackageHeaderResource>> List(Guid[] ids = null, string[] packageIds = null)
            => _httpClientWrapper.List<PackageHeaderResource>(
                UrlTemplate.Resolve(_rootUri + "{?packageIds,ids}", new {ids, packageIds})
            );

        public Task<Stream> Download(PackageHeaderResource package)
            => Download(package.PackageId, package.Version);

        public Task<Stream> Download(string packageId, string version)
            => _httpClientWrapper.Get<Stream>(
                UrlTemplate.Resolve($"{_rootUri}/{packageId}/{version}/download", new {packageId, version})
            );

        public Task Delete(PackageHeaderResource package)
            => Delete(package.PackageId, package.Version);

        public Task Delete(string packageId, string version)
            => _httpClientWrapper.Remove(UrlTemplate.Resolve($"{_rootUri}/{packageId}/{version}", new {packageId, version}));
    }
}