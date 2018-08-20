using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Users
    {
        private const string Root = "users";
        private readonly IHttpClientWrapper _httpClientWrapper;

        internal Users(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public Task<IReadOnlyList<UserResource>> List()
            => _httpClientWrapper.List<UserResource>(Root);

        public Task<UserResource> Get(string id)
            => _httpClientWrapper.Get<UserResource>($"{Root}{id}");


        public Task<UserResource> Create(UserCreateResource resource)
            => _httpClientWrapper.Create<UserResource>(Root, resource);
    }
}