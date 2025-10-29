using Newtonsoft.Json.Linq;

namespace Feedz.Client.Resources
{
    public class NotificationResource
    {
        public required string PartitionKey { get; set; }
        public required string RowKey { get; set; }
        public required string Type { get; set; }
        public required JObject Data { get; set; }
    }
}