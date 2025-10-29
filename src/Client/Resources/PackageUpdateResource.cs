namespace Feedz.Client.Resources
{
    public class PackageUpdateResource : IResource
    {
        public required bool Listed { get; set; }
        public required bool Pinned { get; set; }
    }
}