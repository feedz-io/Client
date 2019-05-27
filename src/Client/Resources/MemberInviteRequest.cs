namespace Feedz.Client.Resources
{
    public class MemberInviteRequest
    {
        public string Addresses { get; set; }
        public Guid[] TeamIds { get; set; }
    }
}