using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public abstract class PackageResource : PackageHeaderResource
    {
        public string DownloadLink { get; set; }
    }

    public class GenericPackageResource : PackageResource
    {
        public GenericPackageResource()
        {
            Type = "Generic";
        }
    }
    
    public class NuGetPackageResource : PackageResource
    {
        public NuGetPackageResource()
        {
            Type = "NuGet";
        }
        
        public IReadOnlyList<string> Authors { get; set; }
        public IReadOnlyList<string> Owners { get; set; }
        public string? Title { get; set; }
        public string? LicenseUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public bool RequireLicenseAcceptance { get; set; }
        public string? Summary { get; set; }
        public string? ReleaseNotes { get; set; }
        public string? Language { get; set; }
        public string? Copyright { get; set; }
        public IReadOnlyList<DependencyGroup> DependencyGroups { get; set; }
        public string? MinClientVersion { get; set; }
        public string? ReportAbuseUrl { get; set; }
        public IReadOnlyList<string?>? SupportedFrameworks { get; set; }
        public bool IsSemVer2 { get; set; }
        public string PackageSha256 { get; set; }

        public class DependencyGroup
        {
            public string? TargetFramework { get; set; }
            public IReadOnlyList<DependencyPackage>? Packages { get; set; }
        }

        public class DependencyPackage
        {
            public string Id { get; set; }
            public string VersionRange { get; set; }
        }
    }

    public class NpmPackageResource : PackageResource
    {
        public NpmPackageResource()
        {
            Type = "Npm";
        }
        
        public string Deprecated { get; set; }
        public Dictionary<string, string> Dependencies { get; set; }
        public Dictionary<string, string> OptionalDependencies { get; set; }
        public Dictionary<string, string> DevDependencies { get; set; }
        public Dictionary<string, string> PeerDependencies { get; set; }
        public Dictionary<string, string> BundleDependencies { get; set; }
        public string Homepage { get; set; }
        public string[] Keywords { get; set; }
        public string License { get; set; }
        public string? Sha1Sum { get; set; }
        public string Readme { get; set; }
        public string? CodeRepositoryUrl { get; set; }
    }
}