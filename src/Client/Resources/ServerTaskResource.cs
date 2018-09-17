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

    public static class ServerTaskStates
    {
        public const string Queued = "Queued";
        public const string Running = "Running";
        public const string Cancelled = "Cancelled";
        public const string Success = "Success";
        public const string Failed = "Failed";
    }
}