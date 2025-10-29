using System;

namespace Feedz.Client.Resources
{
    public class CustomDomainResource : IResource
    {
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid? RepositoryId { get; set; }
        public string Domain { get; set; }
    }
}