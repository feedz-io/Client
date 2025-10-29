using System;

namespace Feedz.Client.Resources
{
    public class ServiceAccountResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Guid OrganisationId { get; set; }
        public required ServiceAccountTeamResource[] Teams { get; set; }
    }

    public class ServiceAccountTeamResource
    {
        public required Guid TeamId { get; set; }
        public required string TeamName { get; set; }
    }
    
}