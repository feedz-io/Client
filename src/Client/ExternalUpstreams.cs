using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class ExternalUpstreams : ApiEndpoint
    {
        internal ExternalUpstreams(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/external-upstreams", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<ExternalUpstreamResource>> List(bool? allowEnablePushingOfPackages = null)
        {
            var uri = RootUri;
            if (allowEnablePushingOfPackages.HasValue)
                uri += $"?allowEnablePushingOfPackages={allowEnablePushingOfPackages.Value}";
            return ApiClientWrapper.List<ExternalUpstreamResource>(uri);
        }

        public Task<ExternalUpstreamResource> Get(Guid id)
            => ApiClientWrapper.Get<ExternalUpstreamResource>($"{RootUri}/{id}");

        public Task<ExternalUpstreamResource> Create(ExternalUpstreamResource resource)
            => ApiClientWrapper.Create<ExternalUpstreamResource>(RootUri, resource);

        public Task<ExternalUpstreamResource> Update(ExternalUpstreamResource resource)
            => ApiClientWrapper.Update<ExternalUpstreamResource>($"{RootUri}/{resource.Id}", resource);

        public Task Remove(ExternalUpstreamResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.Id}");

        public Task<ServerTaskResource> Push(Guid id, PushToExternalUpstreamTaskArgumentsResource arguments)
            => ApiClientWrapper.Create<ServerTaskResource>($"{RootUri}/{id}/push", new ServerTaskQueueRequest<PushToExternalUpstreamTaskArgumentsResource> { Arguments = arguments });
    }
}
