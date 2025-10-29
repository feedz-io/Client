using System;

namespace Feedz.Client.Resources
{
    public class ExternalUpstreamResource : IResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FeedType { get; set; }
        public string Url { get; set; }
        public bool EnablePushingOfPackages { get; set; }
        public string AuthenticationMethod { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
    }
}
