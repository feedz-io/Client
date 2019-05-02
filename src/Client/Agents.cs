using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Agents : ApiEndpoint
    {
        internal Agents(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/agents", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<AgentResource>> List()
            => ApiClientWrapper.List<AgentResource>(RootUri);

        public Task<AgentResource> Get(Guid id)
            => ApiClientWrapper.Get<AgentResource>($"{RootUri}/{id}");

        public Task<AgentResource> Create(AgentResource resource)
            => ApiClientWrapper.Create<AgentResource>(RootUri, resource);

        public Task<AgentResource> Update(AgentResource resource)
            => ApiClientWrapper.Update<AgentResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(AgentResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
        
        public Task<AgentResource> Test(Guid id)
            => ApiClientWrapper.Get<AgentResource>($"{RootUri}/{id}/test");

    }
}