using System;

namespace Feedz.Client.Resources
{
    public class FeedPackageResult
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string PackageId { get; set; }
        public string Version { get; set; }
        public bool IsPrerelease { get; set; }
        public bool Pinned { get; set; }
        public long PackageSize { get; set; }
        public string Extension { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}