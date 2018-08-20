using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public class Integrations : ApiEndpoint
    {
        internal Integrations(RepositoryScope scope, IHttpClientWrapper httpClientWrapper)
            : base($"{scope.RootUri}/integrations", httpClientWrapper)
        {
            OctopusDeploy = new OctopusDeployIntegration(this, httpClientWrapper);
        }

        public OctopusDeployIntegration OctopusDeploy { get; }
    }
}