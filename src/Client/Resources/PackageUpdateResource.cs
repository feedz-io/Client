namespace Feedz.Client.Resources
{
    public class PackageUpdateResource : IResource
    {
        public bool Listed { get; set; }
        public bool Pinned { get; set; }
    }
}