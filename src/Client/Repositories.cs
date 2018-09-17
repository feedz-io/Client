using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Repositories : ApiEndpoint
    {

        internal Repositories(OrganisationScope organisationScope, IHttpClientWrapper httpClientWrapper)
            : base(organisationScope.RootUri + "/repositories", httpClientWrapper)
        {
        }


        public Task<IReadOnlyList<RepositoryResource>> List()
            => HttpClientWrapper.List<RepositoryResource>(RootUri);

        public Task<RepositoryResource> Get(string slug)
            => HttpClientWrapper.Get<RepositoryResource>($"{RootUri}/{slug}");

        public Task<RepositoryResource> Create(RepositoryCreateResource resource)
            => HttpClientWrapper.Create<RepositoryResource>(RootUri, resource);
    }
}