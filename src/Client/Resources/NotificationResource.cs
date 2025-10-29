using Newtonsoft.Json.Linq;

namespace Feedz.Client.Resources
{
    public class NotificationResource
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Type { get; set; }
        public JObject Data { get; set; }
    }
}