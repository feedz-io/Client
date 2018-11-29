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
        private readonly IHttpClientWrapper _apiClientWrapper;
        private readonly IHttpClientWrapper _feedClientWrapper;
        private readonly string _feedRootUri;
        private readonly string _rootUri;

        internal Packages(RepositoryScope scope, IHttpClientWrapper apiClientWrapper, IHttpClientWrapper feedClientWrapper)
        {
            _rootUri = $"{scope.RootUri}/packages";
            _feedRootUri = $"{scope.OrganisationScope.Slug}/{scope.Slug}";
            _apiClientWrapper = apiClientWrapper;
            _feedClientWrapper = feedClientWrapper;
        }

        public Task<PackageHeaderResource> Upload(Stream stream, string originalFilename, bool force = false, string region = null)
        {
            var formValues = new Dictionary<string, string>
            {
                {"force", force.ToString()},
                {"region", region}
            };
            return _feedClientWrapper.Create<PackageHeaderResource>(_feedRootUri, stream, originalFilename, formValues);
        }
        
        public Task<IReadOnlyList<FeedPackageResource>> ListByPackageId(string packageId, string version)
            => _feedClientWrapper.List<FeedPackageResource>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}", new {packageId})
            );
        
        public Task<IReadOnlyList<FeedPackageResource>> All()
            => _feedClientWrapper.List<FeedPackageResource>(
                $"{_feedRootUri}/packages"
            );

        public Task<IReadOnlyList<FeedPackageResource>> ListByPackageId(string packageId)
            => _feedClientWrapper.List<FeedPackageResource>(
                UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}", new {packageId})
            );

        public Task<IReadOnlyList<PackageHeaderResource>> List(Guid[] ids = null, string[] packageIds = null)
            => _apiClientWrapper.List<PackageHeaderResource>(
                UrlTemplate.Resolve(_rootUri + "{?packageIds,ids}", new {ids, packageIds})
            );

        public Task<Stream> Download(FeedPackageResource package)
            => Download(package.PackageId, package.Version);
        
        public Task<Stream> Download(PackageHeaderResource package)
            => Download(package.PackageId, package.Version);

        public Task<Stream> Download(string packageId, string version)
            => _feedClientWrapper.Get<Stream>(
                UrlTemplate.Resolve(_feedRootUri + "/{packageId}/{version}/download", new {packageId, version})
            );

        public Task Delete(FeedPackageResource package)
            => Delete(package.PackageId, package.Version);

        public Task Delete(PackageHeaderResource package)
            => Delete(package.PackageId, package.Version);

        public Task Delete(string packageId, string version)
            => _feedClientWrapper.Remove(UrlTemplate.Resolve(_feedRootUri + "/packages/{packageId}/{version}", new {packageId, version}));
    }
}