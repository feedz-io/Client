using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public class Triggers : ApiEndpoint
    {
        internal Triggers(RepositoryScope scope, IHttpClientWrapper httpClientWrapper)
            : base($"{scope.RootUri}/triggers", httpClientWrapper)
        {
            OctopusCreateRelease = new OctopusCreateReleaseTriggers(this, httpClientWrapper);
        }

        public OctopusCreateReleaseTriggers OctopusCreateRelease { get; }
    }
}