using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Billing : ApiEndpoint
    {
        internal Billing(OrganisationScope organisationScope, IHttpClientWrapper apiClientWrapper)
            : base(organisationScope.RootUri + "/billing", apiClientWrapper)
        {
        }
        
        public Task<BillingResource> Get()
            => ApiClientWrapper.Get<BillingResource>(RootUri);

        public Task<BillingResource> Update(BillingResource resource)
            => ApiClientWrapper.Update<BillingResource>(RootUri, resource);
    }
}