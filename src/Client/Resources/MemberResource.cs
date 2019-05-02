using System;

namespace Feedz.Client.Resources
{
    public class MemberResource : IResource
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MemberTeamResource[] Teams { get; set; }
        public string Email { get; set; }
        public string AuthenticationProvider { get; set; }
    }
    
    public class MemberTeamResource
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
    }
   
}