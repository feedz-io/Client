using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusCreateReleaseTriggerResource : IResource
    {
        public Guid Id { get; set; }
        [Required]
        public string Package { get; set; }
        public string VersionRange { get; set; }
        public string PrereleaseTag { get; set; }

        [Required]
        public string Project { get; set; }
        public string Channel { get; set; }
        public bool Enabled { get; set; }
    }
}