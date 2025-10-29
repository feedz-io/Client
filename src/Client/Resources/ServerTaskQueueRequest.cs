using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class ServerTaskQueueRequest<T> : IResource
    {
        public T Arguments { get; set; }
    }
}