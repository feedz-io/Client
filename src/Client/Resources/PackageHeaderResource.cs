using System;

namespace Feedz.Client.Resources
{
    public class PackageHeaderResource : IResource
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string PackageId { get; set; }
        public string Version { get; set; }
        public bool IsPrerelease { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public bool Listed { get; set; }
        public bool Pinned { get; set; }
        public long PackageSize { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public bool RecentlyUploaded { get; set; }
    }
}