using System;

namespace Feedz.Client.Resources
{
    public class MemberInviteRequest
    {
        public required string Addresses { get; set; }
        public required Guid[] TeamIds { get; set; }
    }
}