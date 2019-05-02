using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Members : ApiEndpoint
    {
        internal Members(OrganisationScope organisationScope, IHttpClientWrapper apiClientWrapper)
            : base(organisationScope.RootUri + "/members", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<MemberResource>> List()
            => ApiClientWrapper.List<MemberResource>(RootUri);

        public Task<MemberResource> Get(Guid id)
            => ApiClientWrapper.Get<MemberResource>($"{RootUri}/{id}");

        public Task<MemberResource> Update(MemberResource resource)
            => ApiClientWrapper.Update<MemberResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(MemberResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
        
        public Task SendInvites(MemberInviteRequest request)
            => ApiClientWrapper.Create($"{RootUri}/invite", request);

    }
}