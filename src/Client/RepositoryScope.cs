using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryScope : ApiEndpoint
    {
        internal RepositoryScope(OrganisationScope organisationScope, string slug, FeedzClient client)
            : base($"{organisationScope.RootUri}/repositories/{slug}", client.ApiClientWrapper)
        {
            OrganisationScope = organisationScope;
            Slug = slug;
            Packages = new Packages(this, client);
            Integrations = new Integrations(this, client.ApiClientWrapper);
            Triggers = new Triggers(this, client.ApiClientWrapper);
            Tasks = new RepositoryServerTasks(this, client.ApiClientWrapper);
            Agents = new Agents(this, client.ApiClientWrapper);
        }

        public OrganisationScope OrganisationScope { get; }
        public string Slug { get; }
        public Packages Packages { get; }
        public Integrations Integrations { get; }
        public Triggers Triggers { get; }
        public RepositoryServerTasks Tasks { get; }
        public Agents Agents { get; }

    }
}