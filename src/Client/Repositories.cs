using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Repositories
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        internal Repositories(OrganisationScope organisationScope, IHttpClientWrapper httpClientWrapper)
        {
            RootUri = organisationScope.RootUri + "/repositories";
            _httpClientWrapper = httpClientWrapper;
        }

        public string RootUri { get; }

        public Task<IReadOnlyList<RepositoryResource>> List()
            => _httpClientWrapper.List<RepositoryResource>(RootUri);

        public Task<RepositoryResource> Get(string slug)
            => _httpClientWrapper.Get<RepositoryResource>($"{RootUri}/{slug}");

        public Task<RepositoryResource> Create(RepositoryCreateResource resource)
            => _httpClientWrapper.Create<RepositoryResource>(RootUri, resource);
    }
}