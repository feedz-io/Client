using System;

namespace Feedz.Client.Resources
{
    public class CustomDomainResource : IResource
    {
        public required Guid Id { get; set; }
        public required Guid OrganisationId { get; set; }
        public Guid? RepositoryId { get; set; }
        public required string Domain { get; set; }
    }
}