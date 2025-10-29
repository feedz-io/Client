using System;

namespace Feedz.Client.Resources
{
    public class FeedPackageResult
    {
        public required Guid Id { get; set; }
        public required string Type { get; set; }
        public required string PackageId { get; set; }
        public required string Version { get; set; }
        public required bool IsPrerelease { get; set; }
        public required bool Pinned { get; set; }
        public required long PackageSize { get; set; }
        public required string Extension { get; set; }
        public required DateTimeOffset Created { get; set; }
    }
}