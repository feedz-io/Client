namespace Feedz.Client.Resources.Integrations.Octopus
{
    public class OctopusCreateFeedResponse
    {
        public required bool Created { get; set; }
        public required string FeedName { get; set; }
    }
}