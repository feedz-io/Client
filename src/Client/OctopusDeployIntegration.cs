using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources.Integrations.Octopus;

namespace Feedz.Client
{
    public class OctopusDeployIntegration : ApiEndpoint
    {
        internal OctopusDeployIntegration(Integrations integrations, IHttpClientWrapper httpClientWrapper)
            : base($"{integrations.RootUri}/octopus-deploy", httpClientWrapper)
        {
        }


        public Task<OctopusIntegrationResource> Get()
            => HttpClientWrapper.Get<OctopusIntegrationResource>(RootUri);

        public Task Modify(OctopusIntegrationResource resource)
            => HttpClientWrapper.Update<OctopusIntegrationResource>(RootUri, resource);

        public Task<OctopusIntegrationTestResponse> Test()
            => HttpClientWrapper.Get<OctopusIntegrationTestResponse>($"{RootUri}/test");

        public Task AddFeed()
            => HttpClientWrapper.Create($"{RootUri}/add-feed");
    }
}