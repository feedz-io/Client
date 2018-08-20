using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class RepositoryCreateResource: IResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public bool IsPublic { get; set; }
        
        public int? KeepForAtLeastDays { get; set; }
        public int? KeepNPrerelease  { get; set; }
        public int? KeepNRelease { get; set; }
    }

    public class RepositoryResource : RepositoryCreateResource
    {
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public string CertificateThumbprint { get; set; }
    }
}