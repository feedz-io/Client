using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class PersonalAccessTokens : ApiEndpoint
    {
        internal PersonalAccessTokens(IHttpClientWrapper httpClientWrapper)
            : base("personal-access-tokens", httpClientWrapper)
        {
        }

        public Task<IReadOnlyList<PersonalAccessTokenResource>> ListForMe()
            => ApiClientWrapper.List<PersonalAccessTokenResource>(RootUri);
        
        public Task<IReadOnlyList<PersonalAccessTokenResource>> ListFor(OrganisationResource organisation)
            => ApiClientWrapper.List<PersonalAccessTokenResource>($"{RootUri}?organisation={organisation.Slug}");

        public Task<PersonalAccessTokenResource> Get(Guid id)
            => ApiClientWrapper.Get<PersonalAccessTokenResource>($"{RootUri}/{id}");

        public Task<CreatePersonalAccessTokenResponse> Create(CreatePersonalAccessTokenRequest request)
            => ApiClientWrapper.Create<CreatePersonalAccessTokenResponse>(RootUri, request);
        
        public Task<PersonalAccessTokenResource> Update(PersonalAccessTokenResource resource)
            => ApiClientWrapper.Update<PersonalAccessTokenResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(PersonalAccessTokenResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
    }
}