using System;

namespace Feedz.Client.Resources
{
    public class PackageVersionResponse : IResource
    {
        public required Guid Id { get; set; }
        public required string PackageId { get; set; }
        public required string Version { get; set; }
        public required int VersionDownloadCount { get; set; }
        public required bool Listed { get; set; }
        public required bool Pinned { get; set; }
        public required long PackageSize { get; set; }
        public required DateTimeOffset LastUpdated { get; set; }
        public required string Tags { get; set; }
    }
}