using System;
using System.Net.Http;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class FeedzClient : IDisposable
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        internal FeedzClient(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            Organisations = new Organisations(httpClientWrapper);
            Users = new Users(httpClientWrapper);
        }

        public Organisations Organisations { get; }
        public Users Users { get; }

        public OrganisationScope ScopeToOrganisation(OrganisationResource organisation)
            => ScopeToOrganisation(organisation.Slug);

        public OrganisationScope ScopeToOrganisation(string slug)
            => new OrganisationScope(slug, _httpClientWrapper);

        public RepositoryScope ScopeToRepository(string orgSlug, string repoSlug)
            => ScopeToOrganisation(orgSlug).ScopeToRepository(repoSlug);

        public async Task<MeResponse> Me()
            => await _httpClientWrapper.Get<MeResponse>("me");

        public static FeedzClient Create(string pat)
            => Create("http://feedz.io", pat);

        public static FeedzClient Create(string pat, String uri)
        {
            var wrapper = new HttpClientWrapper(new Uri(uri), pat);
            return new FeedzClient(wrapper);
        }

        internal static FeedzClient Create(string pat, HttpClient httpClient)
        {
            var wrapper = new HttpClientWrapper(httpClient, pat);
            return new FeedzClient(wrapper);
        }

        public void Dispose()
        {
            _httpClientWrapper.Dispose();
        }
    }
}