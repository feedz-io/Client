using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources.Integrations.Octopus;

namespace Feedz.Client
{
    public class OctopusCreateReleaseTriggers : ApiEndpoint
    {
        internal OctopusCreateReleaseTriggers(Triggers octopus, IHttpClientWrapper httpClientWrapper)
            : base($"{octopus.RootUri}/octopus-create-release", httpClientWrapper)
        {
        }
     
        public Task<IReadOnlyList<OctopusCreateReleaseTriggerResource>> List()
            => HttpClientWrapper.List<OctopusCreateReleaseTriggerResource>(RootUri);

        public Task<OctopusCreateReleaseTriggerResource> Get(Guid id)
            => HttpClientWrapper.Get<OctopusCreateReleaseTriggerResource>($"{RootUri}/{id}");

        public Task<OctopusCreateReleaseTriggerResource> Create(OctopusCreateReleaseTriggerResource resource)
            => HttpClientWrapper.Create<OctopusCreateReleaseTriggerResource>(RootUri, resource);

        public Task<OctopusCreateReleaseTriggerResource> Update(OctopusCreateReleaseTriggerResource resource)
            => HttpClientWrapper.Update<OctopusCreateReleaseTriggerResource>($"{RootUri}/{resource.Id}", resource);

        public Task Delete(OctopusCreateReleaseTriggerResource resource)
            => Delete(resource.Id);
        
        public Task Delete(Guid id)    
            => HttpClientWrapper.Remove($"{RootUri}/{id}");

    }
}