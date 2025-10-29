using System;

namespace Feedz.Client.Resources
{
    public class UserEventResource : IResource
    {
        public required Guid Id { get; set; }
        public required DateTimeOffset Occured { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
    }
}