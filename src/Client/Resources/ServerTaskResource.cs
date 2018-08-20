using System;

namespace Feedz.Client.Resources
{
    public class ServerTaskResource : IResource
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Repository { get; set; }
        public string State { get; set; }
        public DateTimeOffset Queued { get; set; }
        public DateTimeOffset? Started { get; set; }
        public DateTimeOffset? Completed { get; set; }
        public string Message { get; set; }
    }
}