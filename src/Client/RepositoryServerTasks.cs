using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryServerTasks : ApiEndpoint
    {
        internal RepositoryServerTasks(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/tasks", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<ServerTaskResource>> List()
            => ApiClientWrapper.List<ServerTaskResource>(RootUri);
        
        public Task<ServerTaskResource> Get(Guid id)
            => ApiClientWrapper.Get<ServerTaskResource>($"{RootUri}/{id}");

        public Task<ServerTaskResource> QueueImport(ImportTaskArgumentsResource args)
            => ApiClientWrapper.Create<ServerTaskResource>(
                RootUri + "/import",
                new ServerTaskQueueRequest<ImportTaskArgumentsResource>() {Arguments = args}
            );

        public Task<IReadOnlyList<ServerTaskLogLineResource>> Logs(Guid taskId)
            => ApiClientWrapper.Get<IReadOnlyList<ServerTaskLogLineResource>>($"{RootUri}/{taskId}/logs");
    }
}