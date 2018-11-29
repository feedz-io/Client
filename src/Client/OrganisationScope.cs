using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class OrganisationScope
    {
        private readonly IHttpClientWrapper _apiClientWrapper;
        private readonly IHttpClientWrapper _feedClientWrapper;

        internal OrganisationScope(string slug, IHttpClientWrapper apiClientWrapper, IHttpClientWrapper feedClientWrapper)
        {
            Slug = slug;
            RootUri = "organisations/" + slug;
            _apiClientWrapper = apiClientWrapper;
            _feedClientWrapper = feedClientWrapper;
            Repositories = new Repositories(this, apiClientWrapper);
        }

        public string Slug { get; }
        public string RootUri { get; }
        public Repositories Repositories { get; }

        public RepositoryScope ScopeToRepository(RepositoryResource repository)
            => new RepositoryScope(this, repository.Slug, _apiClientWrapper, _feedClientWrapper);

        public RepositoryScope ScopeToRepository(string slug)
            => new RepositoryScope(this, slug, _apiClientWrapper, _feedClientWrapper);
    }
}