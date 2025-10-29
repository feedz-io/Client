using System.Collections.Generic;

namespace Feedz.Client.Resources;

public class PackageRetentionDryRunCommand : IResource
{
    public IReadOnlyList<PackageRetentionRuleResource> Rules { get; set; }
}