using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class OrganisationScope
    {
        private readonly FeedzClient _client;

        internal OrganisationScope(string slug, FeedzClient client)
        {
            _client = client;
            Slug = slug;
            RootUri = "organisations/" + slug;
            Repositories = new Repositories(this, client.ApiClientWrapper);
            Members = new Members(this, client.ApiClientWrapper);
            ServiceAccounts = new ServiceAccounts(this, client.ApiClientWrapper);
            Teams = new Teams(this, client.ApiClientWrapper);
            Billing = new Billing(this, client.ApiClientWrapper);
        }

        public string Slug { get; }
        public string RootUri { get; }
        public Repositories Repositories { get; }
        public Members Members { get; }
        public ServiceAccounts ServiceAccounts { get; }
        public Teams Teams { get; }
        public Billing Billing { get; }
 
        public RepositoryScope ScopeToRepository(RepositoryResource repository)
            => new RepositoryScope(this, repository.Slug, _client);

        public RepositoryScope ScopeToRepository(string slug)
            => new RepositoryScope(this, slug, _client);
    }
}