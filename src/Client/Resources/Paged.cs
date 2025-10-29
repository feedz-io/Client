using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class Paged<T> where T : IResource
    {
        public int TotalResults { get; set; }
        public IReadOnlyList<T> Items { get; set; }
    }
}