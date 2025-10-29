using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class PackageContents : ApiEndpoint
    {
        internal PackageContents(RepositoryScope repositoryScope, IHttpClientWrapper apiClientWrapper)
            : base(repositoryScope.RootUri + "/packages", apiClientWrapper)
        {
        }

        public Task<PackageContentsResource> Get(Guid packageId)
            => ApiClientWrapper.Get<PackageContentsResource>($"{RootUri}/{packageId}/contents");
    }
}
