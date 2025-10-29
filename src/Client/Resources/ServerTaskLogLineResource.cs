using System;

namespace Feedz.Client.Resources
{
    public class ServerTaskLogLineResource : IResource
    {
        public required DateTimeOffset Timestamp { get; set; }
        public required string Level { get; set; }
        public required string Message { get; set; }
    }
}