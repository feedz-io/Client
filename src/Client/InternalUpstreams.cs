using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class InternalUpstreams : ApiEndpoint
    {
        internal InternalUpstreams(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/internal-upstreams", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<InternalUpstreamResource>> List()
            => ApiClientWrapper.List<InternalUpstreamResource>(RootUri);

        public Task<InternalUpstreamResource> Get(Guid id)
            => ApiClientWrapper.Get<InternalUpstreamResource>($"{RootUri}/{id}");

        public Task<InternalUpstreamResource> Create(InternalUpstreamResource resource)
            => ApiClientWrapper.Create<InternalUpstreamResource>(RootUri, resource);

        public Task<InternalUpstreamResource> Update(InternalUpstreamResource resource)
            => ApiClientWrapper.Update<InternalUpstreamResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(InternalUpstreamResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");
    }
}