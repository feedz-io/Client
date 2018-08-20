using System;

namespace Feedz.Client.Resources
{
    public class PackageTransferEventResource : IResource
    {
        public Guid Id { get; set; }
        public string OrganisationSlug { get; set; }
        public string OrganisationName { get; set; }
        public string RepositorySlug { get; set; }
        public string RepositoryName { get; set; }
        public string Package { get; set; }
        public string AccountName { get; set; }
        public long Bytes { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public bool Successful { get; set; }
        public bool IsUpload { get; set; }
    }
}