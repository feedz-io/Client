using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryScope : ApiEndpoint
    {

        internal RepositoryScope(OrganisationScope organisationScope, string slug, IHttpClientWrapper apiClientWrapper, IHttpClientWrapper feedClientWrapper)
            : base($"{organisationScope.RootUri}/repositories/{slug}", apiClientWrapper)
        {
            OrganisationScope = organisationScope;
            Slug = slug;
            Packages = new Packages(this, apiClientWrapper, feedClientWrapper);
            Integrations = new Integrations(this, apiClientWrapper);
            Triggers = new Triggers(this, apiClientWrapper);
            Tasks = new RepositoryServerTasks(this, apiClientWrapper);
        }

        public OrganisationScope OrganisationScope { get; }
        public string Slug { get; }
        public Packages Packages { get; }
        public Integrations Integrations { get; }
        public Triggers Triggers { get; }
        public RepositoryServerTasks Tasks { get; }

    }
}