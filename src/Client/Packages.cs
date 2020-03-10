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
        private readonly string _rootUri;

        internal Packages(RepositoryScope scope, FeedzClient client)
        {
            _client = client;
            _rootUri = $"{scope.RootUri}/packages";
        }

        public Task<IReadOnlyList<PackageResource>> List(Guid[] ids = null, string[] packageIds = null)
            => _client.ApiClientWrapper.List<PackageResource>(
                UrlTemplate.Resolve(_rootUri + "{?packageIds,ids}", new {ids, packageIds})
            );
        
        public Task<PackageResource> GetLatest(string packageId)
            => _client.ApiClientWrapper.Get<PackageResource>(
                UrlTemplate.Resolve(_rootUri + "/{packageId}", new {packageId})
            );
        
        public Task<PackageResource> Get(string packageId, string version)
            => _client.ApiClientWrapper.Get<PackageResource>(
                UrlTemplate.Resolve(_rootUri + "/{packageId}/{version}", new {packageId, version})
            );
    }
}