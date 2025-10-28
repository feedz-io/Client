using System;

namespace Feedz.Client.Resources
{
    public class UserEventResource : IResource
    {
        public Guid Id { get; set; }
        public DateTimeOffset Occured { get; set; }
        public string Type { get; set; }
        public string Description { get; init; }
    }
}