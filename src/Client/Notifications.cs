using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Notifications : ApiEndpoint
    {
        internal Notifications(IHttpClientWrapper httpClientWrapper)
            : base("notifications", httpClientWrapper)
        {
        }

        public Task<IReadOnlyList<NotificationResource>> List()
            => ApiClientWrapper.List<NotificationResource>(RootUri);
        
        public Task Remove(NotificationResource resource)
            => ApiClientWrapper.Remove($"{RootUri}/{resource.PartitionKey}/{resource.RowKey}");
    }
}