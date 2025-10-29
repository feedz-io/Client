using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class ServerTaskQueueRequest<T> : IResource
    {
        public required T Arguments { get; set; }
    }
}