namespace Feedz.Client.Resources
{
    public class InviteProcessRequest : IResource
    {
        public required string Code { get; set; }
    }
}