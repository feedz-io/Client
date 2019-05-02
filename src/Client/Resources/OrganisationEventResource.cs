using System;

namespace Feedz.Client.Resources
{
    public class OrganisationEventResource : IResource
    {
        public Guid Id { get; set; }
        public DateTimeOffset Occured { get; set; }
        public string RepositoryName { get; set; }
        public string RepositorySlug { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}