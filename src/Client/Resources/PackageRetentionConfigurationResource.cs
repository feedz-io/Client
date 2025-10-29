using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class PackageRetentionConfigurationResource : IResource
    {
        public List<PackageRetentionRuleResource> Rules { get; set; }
        public int? DeletedPackageRetentionDays { get; set; }
    }
}
