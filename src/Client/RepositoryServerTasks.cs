using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryServerTasks : ApiEndpoint
    {
        internal RepositoryServerTasks(RepositoryScope repositories, IHttpClientWrapper httpClientWrapper)
            : base(repositories.RootUri + "/tasks", httpClientWrapper)
        {
        }

        public Task<ServerTaskResource> Get(Guid id)
            => HttpClientWrapper.Get<ServerTaskResource>($"{RootUri}/{id}");

        public Task<ServerTaskResource> QueueImport(ImportTaskArgumentsResource args)
            => HttpClientWrapper.Create<ServerTaskResource>(
                RootUri + "/import",
                new ServerTaskQueueRequest<ImportTaskArgumentsResource>() {Arguments = args}
            );

        public Task<IReadOnlyList<ServerTaskLogLineResource>> Logs(Guid taskId)
            => HttpClientWrapper.Get<IReadOnlyList<ServerTaskLogLineResource>>($"{RootUri}/{taskId}/logs");
    }
}