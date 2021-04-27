using System.Collections.Generic;
using System.Threading.Tasks;
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
            PackageFeed = new PackageFeed(this, client);
            Packages = new Packages(this, client);
            Integrations = new Integrations(this, client.ApiClientWrapper);
            Triggers = new Triggers(this, client.ApiClientWrapper);
            Tasks = new RepositoryServerTasks(this, client.ApiClientWrapper);
            Agents = new Agents(this, client.ApiClientWrapper);
            InternalUpstreams = new InternalUpstreams(this, client.ApiClientWrapper);
            CustomDomains = new CustomDomains(this, client.ApiClientWrapper);
        }


        public OrganisationScope OrganisationScope { get; }
        public string Slug { get; }
        public PackageFeed PackageFeed { get; }
        public Packages Packages { get; }
        public Integrations Integrations { get; }
        public Triggers Triggers { get; }
        public RepositoryServerTasks Tasks { get; }
        public Agents Agents { get; }
        public InternalUpstreams InternalUpstreams { get; }
        public CustomDomains CustomDomains { get; }

        public Task<IReadOnlyList<PackageTransferEventResource>> PackageTransferEvents(int skip = 0, int take = 1_000)
            => base.ApiClientWrapper.List<PackageTransferEventResource>($"{RootUri}/package-transfer-events?skip={skip}&take={take}");


    }
}