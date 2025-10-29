using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public abstract class PackageResource : PackageHeaderResource
    {
        public required string DownloadLink { get; set; }
    }

    public class GenericPackageResource : PackageResource
    {
    }
    
    public class NuGetPackageResource : PackageResource
    {
        public required IReadOnlyList<string> Authors { get; set; }
        public required IReadOnlyList<string> Owners { get; set; }
        public string? Title { get; set; }
        public string? LicenseUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public required bool RequireLicenseAcceptance { get; set; }
        public string? Summary { get; set; }
        public string? ReleaseNotes { get; set; }
        public string? Language { get; set; }
        public string? Copyright { get; set; }
        public required IReadOnlyList<DependencyGroup> DependencyGroups { get; set; }
        public string? MinClientVersion { get; set; }
        public string? ReportAbuseUrl { get; set; }
        public string?[]? SupportedFrameworks { get; set; }
        public required bool IsSemVer2 { get; set; }
        public required string PackageSha256 { get; set; }

        public class DependencyGroup
        {
            public string? TargetFramework { get; set; }
            public IReadOnlyList<DependencyPackage>? Packages { get; set; }
        }

        public class DependencyPackage
        {
            public required string Id { get; set; }
            public required string VersionRange { get; set; }
        }
    }

    public class NpmPackageResource : PackageResource
    {
        public required string Deprecated { get; set; }
        public required Dictionary<string, string> Dependencies { get; set; }
        public required Dictionary<string, string> OptionalDependencies { get; set; }
        public required Dictionary<string, string> DevDependencies { get; set; }
        public required Dictionary<string, string> PeerDependencies { get; set; }
        public required Dictionary<string, string> BundleDependencies { get; set; }
        public required string Homepage { get; set; }
        public required string[] Keywords { get; set; }
        public required string License { get; set; }
        public string? Sha1Sum { get; set; }
        public required string Readme { get; set; }
        public string? CodeRepositoryUrl { get; set; }
    }
}