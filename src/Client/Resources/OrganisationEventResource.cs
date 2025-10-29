using System;

namespace Feedz.Client.Resources
{
    public class OrganisationEventResource : IResource
    {
        public required Guid Id { get; set; }
        public required DateTimeOffset Occured { get; set; }
        public required string RepositoryName { get; set; }
        public required string RepositorySlug { get; set; }
        public required string AccountName { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
    }
}