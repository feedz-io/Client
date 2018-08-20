using System;

namespace Feedz.Client.Resources
{
    public class PackageVersionResponse : IResource
    {
        public Guid Id { get; set; }
        public string PackageId { get; set; }
        public string Version { get; set; }
        public int DownloadCount { get; set; }
        public bool Listed { get; set; }
        public bool Pinned { get; set; }
        public long PackageSize { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}