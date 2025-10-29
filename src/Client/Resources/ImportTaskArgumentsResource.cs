using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class ImportTaskArgumentsResource
    {
        public required string Url { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}