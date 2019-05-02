using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Teams : ApiEndpoint
    {
        internal Teams(OrganisationScope organisationScope, IHttpClientWrapper apiClientWrapper)
            : base(organisationScope.RootUri + "/teams", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<TeamResource>> List()
            => ApiClientWrapper.List<TeamResource>(RootUri);

        public Task<TeamResource> Get(Guid id)
            => ApiClientWrapper.Get<TeamResource>($"{RootUri}/{id}");

        public Task<TeamResource> Create(TeamResource resource)
            => ApiClientWrapper.Create<TeamResource>(RootUri, resource);

        public Task<TeamResource> Update(TeamResource resource)
            => ApiClientWrapper.Update<TeamResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(TeamResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
    }
}