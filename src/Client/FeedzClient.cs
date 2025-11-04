using System;
using System.Net.Http;
using System.Threading.Tasks;
using Feedz.Client.Logging;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class FeedzClient : IDisposable
    {
      
        internal FeedzClient(IHttpClientWrapper apiClientWrapper, IHttpClientWrapper feedClientWrapper)
        {
            ApiClientWrapper = apiClientWrapper;
            FeedClientWrapper = feedClientWrapper;
            Organisations = new Organisations(apiClientWrapper);
            Users = new Users(apiClientWrapper);
            Invites = new Invites(apiClientWrapper);
            Notifications = new Notifications(apiClientWrapper);
            PersonalAccessTokens = new PersonalAccessTokens(apiClientWrapper);
            Log = new EmptyFeedzLogger();
        }


        public IHttpClientWrapper ApiClientWrapper { get; }
        public IHttpClientWrapper FeedClientWrapper { get; }

        public IFeedzLogger Log { get; set; }
        public Organisations Organisations { get; }
        public Invites Invites { get; }
        public Users Users { get; }
        public Notifications Notifications { get; }

        public PersonalAccessTokens PersonalAccessTokens { get; }

        public TimeSpan FeedTimeout
        {
            get => FeedClientWrapper.Timeout;
            set => FeedClientWrapper.Timeout = value;
        }
        
        public TimeSpan ApiTimeout
        {
            get => ApiClientWrapper.Timeout;
            set => ApiClientWrapper.Timeout = value;
        }

        public OrganisationScope ScopeToOrganisation(OrganisationResource organisation)
            => ScopeToOrganisation(organisation.Slug);

        public OrganisationScope ScopeToOrganisation(string slug)
            => new OrganisationScope(slug, this);

        public RepositoryScope ScopeToRepository(string orgSlug, string repoSlug)
            => ScopeToOrganisation(orgSlug).ScopeToRepository(repoSlug);

        public async Task<MeResponse> Me()
            => await ApiClientWrapper.Get<MeResponse>("me");

        public static FeedzClient CreateAnonymous()
            => Create(null);
        
        public static FeedzClient Create(string pat)
            => Create(pat, "https://feedz.io", "https://f.feedz.io");

        public static FeedzClient Create(string pat, string apiUri, string feedUri)
            => Create(pat, new Uri(apiUri), new Uri(feedUri));

        public static FeedzClient Create(string pat, Uri apiUri, Uri feedUri)
        {
            var apiClientWrapper = new HttpClientWrapper(new Uri(apiUri, "api/"), pat);
            var feedClientWrapper = new FeedClientWrapper(feedUri, pat);
            return new FeedzClient(apiClientWrapper, feedClientWrapper);
        }

        public static FeedzClient Create(string pat, HttpClient apiClient, HttpClient feedClient)
        {
            var apiClientWrapper = new HttpClientWrapper(apiClient, pat);
            var feedClientWrapper = new FeedClientWrapper(feedClient, pat);
            return new FeedzClient(apiClientWrapper, feedClientWrapper);
        }

        public void Dispose()
        {
            ApiClientWrapper.Dispose();
        }
    }
}