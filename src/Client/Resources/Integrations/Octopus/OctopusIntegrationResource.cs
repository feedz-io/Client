namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusIntegrationResource : IResource
    {
        public required bool Enabled { get; set; }
        public required string Url { get; set; }
        public required string ApiKey { get; set; }
    }
}