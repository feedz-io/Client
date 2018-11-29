using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public class Integrations : ApiEndpoint
    {
        internal Integrations(RepositoryScope scope, IHttpClientWrapper apiClientWrapper)
            : base($"{scope.RootUri}/integrations", apiClientWrapper)
        {
            OctopusDeploy = new OctopusDeployIntegration(this, apiClientWrapper);
        }

        public OctopusDeployIntegration OctopusDeploy { get; }
    }
}