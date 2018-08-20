using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public abstract class ApiEndpoint
    {
        internal ApiEndpoint(string rootUri, IHttpClientWrapper httpClientWrapper)
        {
            RootUri = rootUri;
            HttpClientWrapper = httpClientWrapper;
        }

        public string RootUri { get; }
        internal IHttpClientWrapper HttpClientWrapper { get; }
    }
}