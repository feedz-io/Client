using System;

namespace Feedz.Client.Resources
{
    public class PackageTransferEventResource : IResource
    {
        public required Guid Id { get; set; }
        public required string OrganisationSlug { get; set; }
        public required string OrganisationName { get; set; }
        public required string RepositorySlug { get; set; }
        public required string RepositoryName { get; set; }
        public required string Package { get; set; }
        public required string AccountName { get; set; }
        public required long Bytes { get; set; }
        public long? DeltaBytes { get; set; }
        public required DateTimeOffset StartedAt { get; set; }
        public required bool Successful { get; set; }
        public required string Direction { get; set; }
    }
}