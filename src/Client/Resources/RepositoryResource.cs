using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class RepositoryCreateResource: IResource
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }

        public required bool IsPublic { get; set; }

        public int? KeepForAtLeastDays { get; set; }
        public int? KeepNPrerelease  { get; set; }
        public int? KeepNRelease { get; set; }
        public int? DeletedPackageRetentionDays { get; set; }
    }

    public class RepositoryResource : RepositoryCreateResource
    {
        public required Guid Id { get; set; }
        public required Guid OrganisationId { get; set; }
        public required string CertificateThumbprint { get; set; }
        public required bool AutoRepack { get; set; }
        public required bool FeedUsed { get; set; }
        public required bool PatCreated { get; set; }
    }
}