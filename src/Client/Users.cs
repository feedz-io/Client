using System;
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

        public Task<UserResource> Me()
            => _httpClientWrapper.Get<UserResource>($"{Root}/me");

        public Task<UserResource> Update(UserResource resource)
            => _httpClientWrapper.Update<UserResource>($"{Root}/{resource.Id}", resource);
        
        public Task<IReadOnlyList<UserEventResource>> Events(UserResource resource)
            => _httpClientWrapper.List<UserEventResource>($"{Root}/{resource.Id}/events");
    }
}