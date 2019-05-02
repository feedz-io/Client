using System;

namespace Feedz.Client.Resources
{
    public class ServiceAccountResource : IResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OrganisationId { get; set; }
        public ServiceAccountTeamResource[] Teams { get; set; } 
    }

    public class ServiceAccountTeamResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
}