using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class ImportTaskArgumentsResource
    {
        [Required]
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}