using System;
using System.Collections.Generic;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Feedz.Client.Tests.Plumbing.Converters
{
    public class PackageJsonConverterTests
    {
        [Test]
        public void NuGet()
        {
            var package = new NuGetPackageResource()
            {
                Id = Guid.NewGuid(),
                Type = "NuGet",
                PackageId = "Test.Package",
                Version = "1.0.0",
                IsPrerelease = false,
                Listed = true,
                Pinned = false,
                PackageSize = 1024,
                Created = DateTimeOffset.UtcNow,
                LastUpdated = DateTimeOffset.UtcNow,
                RecentlyUploaded = false,
                IsUpstream = false,
                VersionDownloadCount = 0,
                DownloadCount = 0,
                DownloadLink = "https://example.com/download",
                Authors = new List<string> { "Test Author" },
                Owners = new List<string> { "Test Owner" },
                RequireLicenseAcceptance = false,
                DependencyGroups = new List<NuGetPackageResource.DependencyGroup>(),
                IsSemVer2 = false,
                PackageSha256 = "sha256hash"
            };
            Execute(package).Should().BeOfType<NuGetPackageResource>();
        }

        [Test]
        public void Generic()
        {
            var package = new GenericPackageResource()
            {
                Id = Guid.NewGuid(),
                Type = "Generic",
                PackageId = "Test.Package",
                Version = "1.0.0",
                IsPrerelease = false,
                Listed = true,
                Pinned = false,
                PackageSize = 1024,
                Created = DateTimeOffset.UtcNow,
                LastUpdated = DateTimeOffset.UtcNow,
                RecentlyUploaded = false,
                IsUpstream = false,
                VersionDownloadCount = 0,
                DownloadCount = 0,
                DownloadLink = "https://example.com/download"
            };
            Execute(package).Should().BeOfType<GenericPackageResource>();
        }

        [Test]
        public void Npm()
        {
            var package = new NpmPackageResource()
            {
                Id = Guid.NewGuid(),
                Type = "Npm",
                PackageId = "test-package",
                Version = "1.0.0",
                IsPrerelease = false,
                Listed = true,
                Pinned = false,
                PackageSize = 1024,
                Created = DateTimeOffset.UtcNow,
                LastUpdated = DateTimeOffset.UtcNow,
                RecentlyUploaded = false,
                IsUpstream = false,
                VersionDownloadCount = 0,
                DownloadCount = 0,
                DownloadLink = "https://example.com/download",
                Deprecated = "",
                Dependencies = new Dictionary<string, string>(),
                OptionalDependencies = new Dictionary<string, string>(),
                DevDependencies = new Dictionary<string, string>(),
                PeerDependencies = new Dictionary<string, string>(),
                BundleDependencies = new Dictionary<string, string>(),
                Homepage = "https://example.com",
                Keywords = [],
                License = "MIT",
                Readme = "# Test Package"
            };
            Execute(package).Should().BeOfType<NpmPackageResource>();
        }

        private static PackageResource? Execute(PackageResource orig)
        {
            var json = JsonConvert.SerializeObject(orig, HttpClientWrapper.JsonSerializerSettings);
            return JsonConvert.DeserializeObject<PackageResource>(json, HttpClientWrapper.JsonSerializerSettings);
        }
    }
}