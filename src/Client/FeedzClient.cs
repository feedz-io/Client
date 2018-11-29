using System;
using System.Net.Http;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class FeedzClient : IDisposable
    {
        private readonly IHttpClientWrapper _apiClientWrapper;
        private readonly IHttpClientWrapper _feedClientWrapper;

        internal FeedzClient(IHttpClientWrapper apiClientWrapper, IHttpClientWrapper feedClientWrapper)
        {
            _apiClientWrapper = apiClientWrapper;
            _feedClientWrapper = feedClientWrapper;
            Organisations = new Organisations(apiClientWrapper);
            Users = new Users(apiClientWrapper);
        }

        public Organisations Organisations { get; }
        public Users Users { get; }

        public OrganisationScope ScopeToOrganisation(OrganisationResource organisation)
            => ScopeToOrganisation(organisation.Slug);

        public OrganisationScope ScopeToOrganisation(string slug)
            => new OrganisationScope(slug, _apiClientWrapper, _feedClientWrapper);

        public RepositoryScope ScopeToRepository(string orgSlug, string repoSlug)
            => ScopeToOrganisation(orgSlug).ScopeToRepository(repoSlug);

        public async Task<MeResponse> Me()
            => await _apiClientWrapper.Get<MeResponse>("me");

        public static FeedzClient CreateAnonymous()
            => Create(null);
        
        public static FeedzClient Create(string pat)
            => Create(pat, "https://feedz.io", "https://f.feedz.io");

        public static FeedzClient Create(string pat, string apiUri, string feedUri)
            => Create(pat, new Uri(apiUri), new Uri(feedUri));

        public static FeedzClient Create(string pat, Uri apiUri, Uri feedUri)
        {
            if (!apiUri.IsLoopback)
                apiUri = new Uri(apiUri, "api/");
            
            var apiClientWrapper = new HttpClientWrapper(apiUri, pat);
            var feedClientWrapper = new HttpClientWrapper(feedUri, pat);
            return new FeedzClient(apiClientWrapper, feedClientWrapper);
        }

        public static FeedzClient Create(string pat, HttpClient apiClient, HttpClient feedClient)
        {
            var apiClientWrapper = new HttpClientWrapper(apiClient, pat);
            var feedClientWrapper = new HttpClientWrapper(feedClient, pat);
            return new FeedzClient(apiClientWrapper, feedClientWrapper);
        }

        public void Dispose()
        {
            _apiClientWrapper.Dispose();
        }
    }
}