using System;

namespace Feedz.Client.Resources
{
    public class MemberResource : IResource
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOwner { get; set; }
    }
}