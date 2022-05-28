using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class Invites
    {
        private const string Root = "invite";
        private readonly IHttpClientWrapper _httpClientWrapper;

        internal Invites(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public Task<InviteProcessResponse> Process(InviteProcessRequest resource)
            => _httpClientWrapper.Create<InviteProcessResponse>(Root, resource);
    }
}