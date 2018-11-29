using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public class Triggers : ApiEndpoint
    {
        internal Triggers(RepositoryScope scope, IHttpClientWrapper apiClientWrapper)
            : base($"{scope.RootUri}/triggers", apiClientWrapper)
        {
            OctopusCreateRelease = new OctopusCreateReleaseTriggers(this, apiClientWrapper);
        }

        public OctopusCreateReleaseTriggers OctopusCreateRelease { get; }
    }
}