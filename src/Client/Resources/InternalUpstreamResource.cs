using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class InternalUpstreamResource : IResource
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UpstreamRepositoryId { get; set; }

        public string UpstreamRepositorySlug { get; set; }
        public string UpstreamRepositoryName { get; set; }

        [Required]
        public string PackageRegex { get; set; }
    }
}