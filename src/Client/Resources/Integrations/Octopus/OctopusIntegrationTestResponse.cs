namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusIntegrationTestResponse {
        public required bool Success { get; set; }
        public required string Message { get; set; }
        public required string FeedName { get; set; }
    }
}