using System;

namespace Feedz.Client.Resources
{
    public class PackageHeaderResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Type { get; set; }
        public required string PackageId { get; set; }
        public required string Version { get; set; }
        public required bool IsPrerelease { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public required bool Listed { get; set; }
        public required bool Pinned { get; set; }
        public required long PackageSize { get; set; }
        public required DateTimeOffset Created { get; set; }
        public required DateTimeOffset LastUpdated { get; set; }
        public required bool RecentlyUploaded { get; set; }
        public required bool IsUpstream { get; set; }
        public required int VersionDownloadCount { get; set; }
        public required int DownloadCount { get; set; }
    }
}