using System;

namespace Feedz.Client.Resources
{
    public class DeletedPackageResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Type { get; set; }
        public required string PackageId { get; set; }
        public required string Version { get; set; }
        public required DateTimeOffset DeletedAt { get; set; }
        public required bool SameVersionExists { get; set; }
    }
}
