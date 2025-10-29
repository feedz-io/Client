using System;

namespace Feedz.Client.Resources
{
    public class ServerTaskLogLineResource : IResource
    {
        public DateTimeOffset Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}