using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryScope : ApiEndpoint
    {
        internal RepositoryScope(OrganisationScope organisationScope, string slug, IHttpClientWrapper httpClientWrapper)
            : base($"{organisationScope.RootUri}/repositories/{slug}", httpClientWrapper)
        {
            Packages = new Packages(this, httpClientWrapper);
            Integrations = new Integrations(this, httpClientWrapper);
            Triggers = new Triggers(this, httpClientWrapper);
        }

        public Packages Packages { get; }
        public Integrations Integrations { get; }
        public Triggers Triggers { get; }
    }
}