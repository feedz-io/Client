namespace Feedz.Client.Resources
{
    public class PackageDeltaSignatureResult
    {
        public required byte[] Signature { get; set; }
        public required string BaseVersion { get; set; }
    }
}