namespace Feedz.Client.Resources
{
    public class PackageRetentionRuleResource : IResource
    {
        public string PackageName { get; set; }
        public string NameMatch { get; set; }
        public int ReleaseKeepIfUploadedInLastNDays { get; set; }
        public int ReleaseKeepNMostRecentlyUploaded { get; set; }
        public int PrereleaseKeepIfUploadedInLastNDays { get; set; }
        public int PrereleaseKeepNMostRecentlyUploaded { get; set; }
    }
}
