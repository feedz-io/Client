using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Repositories : ApiEndpoint
    {

        internal Repositories(OrganisationScope organisationScope, IHttpClientWrapper apiClientWrapper)
            : base(organisationScope.RootUri + "/repositories", apiClientWrapper)
        {
        }


        public Task<IReadOnlyList<RepositoryResource>> List()
            => ApiClientWrapper.List<RepositoryResource>(RootUri);

        public Task<RepositoryResource> Get(string slug)
            => ApiClientWrapper.Get<RepositoryResource>($"{RootUri}/{slug}");

        public Task<RepositoryResource> Create(RepositoryCreateResource resource)
            => ApiClientWrapper.Create<RepositoryResource>(RootUri, resource);
        
        public Task<RepositoryResource> Update(RepositoryResource resource, string? currentSlug = null)
            => ApiClientWrapper.Update<RepositoryResource>($"{RootUri}/{currentSlug ?? resource.Slug}", resource);

        public Task Remove(RepositoryResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Slug}");
    }
}