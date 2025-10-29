using System;

namespace Feedz.Client.Resources
{
    public class MemberResource : IResource
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required MemberTeamResource[] Teams { get; set; }
        public required string Email { get; set; }
        public required string AuthenticationProvider { get; set; }
    }
    
    public class MemberTeamResource
    {
        public required Guid TeamId { get; set; }
        public required string TeamName { get; set; }
    }
   
}