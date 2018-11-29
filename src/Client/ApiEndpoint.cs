using Feedz.Client.Plumbing;

namespace Feedz.Client
{
    public abstract class ApiEndpoint
    {
        internal ApiEndpoint(string rootUri, IHttpClientWrapper apiClientWrapper)
        {
            RootUri = rootUri;
            ApiClientWrapper = apiClientWrapper;
        }

        public string RootUri { get; }
        internal IHttpClientWrapper ApiClientWrapper { get; }
    }
}