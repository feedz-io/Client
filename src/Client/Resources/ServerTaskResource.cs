using System;

namespace Feedz.Client.Resources
{
    public class ServerTaskResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Repository { get; set; }
        public required string State { get; set; }
        public required DateTimeOffset Queued { get; set; }
        public DateTimeOffset? Started { get; set; }
        public DateTimeOffset? Completed { get; set; }
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