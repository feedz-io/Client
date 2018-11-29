using System.Net;
using System.Net.Http;

namespace Feedz.Client.Plumbing
{
    public class FeedzHttpRequestException : HttpRequestException
    {
        public HttpStatusCode Code { get; }

        public FeedzHttpRequestException(HttpStatusCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}