using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class ServiceAccounts : ApiEndpoint
    {
        internal ServiceAccounts(OrganisationScope organisationScope, IHttpClientWrapper apiClientWrapper)
            : base(organisationScope.RootUri + "/service-accounts", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<ServiceAccountResource>> List()
            => ApiClientWrapper.List<ServiceAccountResource>(RootUri);

        public Task<ServiceAccountResource> Get(Guid id)
            => ApiClientWrapper.Get<ServiceAccountResource>($"{RootUri}/{id}");

        public Task<ServiceAccountResource> Create(ServiceAccountResource resource)
            => ApiClientWrapper.Create<ServiceAccountResource>(RootUri, resource);

        public Task<ServiceAccountResource> Update(ServiceAccountResource resource)
            => ApiClientWrapper.Update<ServiceAccountResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(ServiceAccountResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
    }
}