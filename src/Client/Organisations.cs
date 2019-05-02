using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Organisations : ApiEndpoint
    {
        internal Organisations(IHttpClientWrapper httpClientWrapper)
            : base("organisations", httpClientWrapper)
        {
        }

        public Task<IReadOnlyList<OrganisationResource>> List()
            => ApiClientWrapper.List<OrganisationResource>(RootUri);

        public Task<OrganisationResource> Get(string slug)
            => ApiClientWrapper.Get<OrganisationResource>($"{RootUri}/{slug}");

        public Task<OrganisationResource> Create(OrganisationCreateResource resource)
            => ApiClientWrapper.Create<OrganisationResource>(RootUri, resource);
        
        public Task<OrganisationResource> Update(OrganisationResource resource, string currentSlug = null)
            => ApiClientWrapper.Update<OrganisationResource>($"{RootUri}/{currentSlug ?? resource.Slug}", resource);

        public Task Remove(OrganisationResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Slug}");
    }
}