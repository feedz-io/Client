using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusCreateReleaseTriggerResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Package { get; set; }
        public required string VersionRange { get; set; }
        public required string PrereleaseTag { get; set; }

        public required string Project { get; set; }
        public required string Channel { get; set; }
        public required bool Enabled { get; set; }
    }
}