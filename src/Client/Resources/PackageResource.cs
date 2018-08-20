using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class PackageResource : PackageHeaderResource
    {
        public IReadOnlyList<string> Authors { get; set; }
        public IReadOnlyList<string> Owners { get; set; }
        public string Title { get; set; }
        public string LicenseUrl { get; set; }
        public string ProjectUrl { get; set; }
        public bool RequireLicenseAcceptance { get; set; }
        public bool DevelopmentDependency { get; set; }
        public string Summary { get; set; }
        public string ReleaseNotes { get; set; }
        public string Language { get; set; }
        public string Copyright { get; set; }
        public IReadOnlyList<DependencyGroup> DependencyGroups { get; set; }
        public string MinClientVersion { get; set; }
        public string ReportAbuseUrl { get; set; }
        public IReadOnlyList<string> SupportedFrameworks { get; set; }
        public bool SemVer1IsAbsoluteLatest { get; set; }
        public bool SemVer1IsLatest { get; set; }
        public bool SemVer2IsAbsoluteLatest { get; set; }
        public bool SemVer2IsLatest { get; set; }
        public bool IsSemVer2 { get; set; }
        public string PackageHash { get; set; }
        public string PackageHashAlgorithm { get; set; }

        public class DependencyGroup
        {
            public string TargetFramework { get; set; }
            public IReadOnlyList<DependencyPackage> Packages { get; set; }
        }

        public class DependencyPackage
        {
            public string Id { get; set; }
            public string VersionRange { get; set; }
        }
    }
}