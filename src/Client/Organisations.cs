using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Organisations
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly string _root;

        internal Organisations(IHttpClientWrapper httpClientWrapper)
        {
            _root = "organisations";
            _httpClientWrapper = httpClientWrapper;
        }

        public Task<IReadOnlyList<OrganisationResource>> List()
            => _httpClientWrapper.List<OrganisationResource>(_root);

        public Task<OrganisationResource> Get(string slug)
            => _httpClientWrapper.Get<OrganisationResource>($"{_root}/{slug}");

        public Task<OrganisationResource> Create(OrganisationCreateResource resource)
            => _httpClientWrapper.Create<OrganisationResource>(_root, resource);
    }
}