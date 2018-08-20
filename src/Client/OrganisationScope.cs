using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class OrganisationScope
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        internal OrganisationScope(string slug, IHttpClientWrapper httpClientWrapper)
        {
            RootUri = "organisations/" + slug;
            _httpClientWrapper = httpClientWrapper;
            Repositories = new Repositories(this, httpClientWrapper);
        }

        public string RootUri { get; }
        public Repositories Repositories { get; }

        public RepositoryScope ScopeToRepository(RepositoryResource repository)
            => new RepositoryScope(this, repository.Slug, _httpClientWrapper);

        public RepositoryScope ScopeToRepository(string slug)
            => new RepositoryScope(this, slug, _httpClientWrapper);
    }
}