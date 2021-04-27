using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class CustomDomains : ApiEndpoint
    {
        internal CustomDomains(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/custom-domains", apiClientWrapper)
        {
        }

        internal CustomDomains(OrganisationScope organisation, IHttpClientWrapper apiClientWrapper)
            : base(organisation.RootUri + "/custom-domains", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<CustomDomainResource>> List()
            => ApiClientWrapper.List<CustomDomainResource>(RootUri);

        public Task<CustomDomainResource> Get(Guid id)
            => ApiClientWrapper.Get<CustomDomainResource>($"{RootUri}/{id}");

        public Task<CustomDomainResource> Create(CustomDomainResource resource)
            => ApiClientWrapper.Create<CustomDomainResource>(RootUri, resource);

        public Task Remove(CustomDomainResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
    }
}