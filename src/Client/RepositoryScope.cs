using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class RepositoryScope : ApiEndpoint
    {
        private readonly FeedzClient _client;

        internal RepositoryScope(OrganisationScope organisationScope, string slug, FeedzClient client)
            : base($"{organisationScope.RootUri}/repositories/{slug}", client.ApiClientWrapper)
        {
            _client = client;
            OrganisationScope = organisationScope;
            Slug = slug;
            Packages = new Packages(this, _client);
            Integrations = new Integrations(this, _client.ApiClientWrapper);
            Triggers = new Triggers(this, _client.ApiClientWrapper);
            Tasks = new RepositoryServerTasks(this, _client.ApiClientWrapper);
        }

        public OrganisationScope OrganisationScope { get; }
        public string Slug { get; }
        public Packages Packages { get; }
        public Integrations Integrations { get; }
        public Triggers Triggers { get; }
        public RepositoryServerTasks Tasks { get; }

    }
}