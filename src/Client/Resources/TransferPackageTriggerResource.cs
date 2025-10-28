using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class TransferPackageTriggerResource : IResource
    {
        public Guid Id { get; set; }
        public string Package { get; set; }
        public string VersionRange { get; set; }
        public string PrereleaseTag { get; set; }

        public string[] Roles { get; set; }
        public bool Enabled { get; set; }
    }
}