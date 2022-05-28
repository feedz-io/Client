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
            => Execute(new NuGetPackageResource()).Should().BeOfType<NuGetPackageResource>();

        [Test]
        public void Generic()
            => Execute(new GenericPackageResource()).Should().BeOfType<GenericPackageResource>();

        [Test]
        public void Npm()
            => Execute(new NpmPackageResource()).Should().BeOfType<NpmPackageResource>();

        private static PackageResource Execute(PackageResource orig)
        {
            var json = JsonConvert.SerializeObject(orig, HttpClientWrapper.JsonSerializerSettings);
            return JsonConvert.DeserializeObject<PackageResource>(json, HttpClientWrapper.JsonSerializerSettings);
        }
    }
}