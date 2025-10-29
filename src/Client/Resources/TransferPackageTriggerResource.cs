using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class TransferPackageTriggerResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Package { get; set; }
        public required string VersionRange { get; set; }
        public required string PrereleaseTag { get; set; }

        public required string[] Roles { get; set; }
        public required bool Enabled { get; set; }
    }
}