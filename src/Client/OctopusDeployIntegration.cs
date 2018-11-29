using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources.Integrations.Octopus;

namespace Feedz.Client
{
    public class OctopusDeployIntegration : ApiEndpoint
    {
        internal OctopusDeployIntegration(Integrations integrations, IHttpClientWrapper apiClientWrapper)
            : base($"{integrations.RootUri}/octopus-deploy", apiClientWrapper)
        {
        }


        public Task<OctopusIntegrationResource> Get()
            => ApiClientWrapper.Get<OctopusIntegrationResource>(RootUri);

        public Task Modify(OctopusIntegrationResource resource)
            => ApiClientWrapper.Update<OctopusIntegrationResource>(RootUri, resource);

        public Task<OctopusIntegrationTestResponse> Test()
            => ApiClientWrapper.Get<OctopusIntegrationTestResponse>($"{RootUri}/test");

        public Task AddFeed()
            => ApiClientWrapper.Create($"{RootUri}/add-feed");
    }
}