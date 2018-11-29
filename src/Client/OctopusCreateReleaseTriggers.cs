using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources.Integrations.Octopus;

namespace Feedz.Client
{
    public class OctopusCreateReleaseTriggers : ApiEndpoint
    {
        internal OctopusCreateReleaseTriggers(Triggers octopus, IHttpClientWrapper apiClientWrapper)
            : base($"{octopus.RootUri}/octopus-create-release", apiClientWrapper)
        {
        }
     
        public Task<IReadOnlyList<OctopusCreateReleaseTriggerResource>> List()
            => ApiClientWrapper.List<OctopusCreateReleaseTriggerResource>(RootUri);

        public Task<OctopusCreateReleaseTriggerResource> Get(Guid id)
            => ApiClientWrapper.Get<OctopusCreateReleaseTriggerResource>($"{RootUri}/{id}");

        public Task<OctopusCreateReleaseTriggerResource> Create(OctopusCreateReleaseTriggerResource resource)
            => ApiClientWrapper.Create<OctopusCreateReleaseTriggerResource>(RootUri, resource);

        public Task<OctopusCreateReleaseTriggerResource> Update(OctopusCreateReleaseTriggerResource resource)
            => ApiClientWrapper.Update<OctopusCreateReleaseTriggerResource>($"{RootUri}/{resource.Id}", resource);

        public Task Delete(OctopusCreateReleaseTriggerResource resource)
            => Delete(resource.Id);
        
        public Task Delete(Guid id)    
            => ApiClientWrapper.Remove($"{RootUri}/{id}");

    }
}