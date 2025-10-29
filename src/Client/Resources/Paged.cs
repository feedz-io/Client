using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class Paged<T> where T : IResource
    {
        public required int TotalResults { get; set; }
        public required IReadOnlyList<T> Items { get; set; }
    }
}