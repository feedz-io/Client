using System.Collections.Generic;

namespace Feedz.Client.Resources;

public class PackageContentsResource
{
    public required IReadOnlyList<PackageContentsFileResource> Files { get; set; }
}

public class PackageContentsFileResource
{
    public required string FullName { get; set; }
    public required long Size { get; set; }
    public required string Md5 { get; set; }
    public required string Sha1 { get; set; }
    public required string? AssemblyFullName { get; set; }
}