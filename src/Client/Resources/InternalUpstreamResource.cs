using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class InternalUpstreamResource : IResource
    {
        public required Guid Id { get; set; }

        public required Guid UpstreamRepositoryId { get; set; }

        public required string UpstreamRepositorySlug { get; set; }
        public required string UpstreamRepositoryName { get; set; }

        public required string PackageRegex { get; set; }
    }
}