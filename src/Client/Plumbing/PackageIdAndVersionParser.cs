using System;
using System.Linq;

namespace Feedz.Client.Plumbing
{
    public static class PackageIdAndVersionParser
    {
        private const string errorStr = "The filename must contain the package id followed by a valid Semantic or NuGet version. e.g. My.Package.1.2.3-alpha+abc, My.Package.1";

        public static (string packageId, string version) Parse(string str)
        {
            var parts = str.Split('.');
            var firstNumeric = FindFirstNumeric(parts);
            if (firstNumeric == null)
                throw new Exception($"No version found in the filename {str}. {errorStr}");

            var packageId = string.Join(".", parts.Take(firstNumeric.Value));
            var version = string.Join(".", parts.Skip(firstNumeric.Value));

            return (packageId, version);
        }

        private static int? FindFirstNumeric(string[] parts)
        {
            for (var x = 1; x < parts.Length; x++)
                if (parts[x] != "" && parts[x].All(char.IsDigit))
                    return x;

            return null;
        }
    }
}