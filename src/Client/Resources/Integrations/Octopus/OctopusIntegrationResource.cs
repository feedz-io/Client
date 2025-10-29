namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusIntegrationResource : IResource
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
    }
}