using System;
using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class TeamResource : IResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid OrganisationId { get; set; }
        public bool IsBuiltIn { get; set; }

        public bool ViewTeamsMembersAndServiceAccounts { get; set; }
        public bool ManageTeamsMembersAndServiceAccounts { get; set; }
        public bool ManageOrganisation { get; set; }
        public bool ManageSubscription { get; set; }
        public bool ViewEvents { get; set; }
        public bool AddRepositories { get; set; }
        public bool RemoveRepositories { get; set; }

        public bool AllRepositories { get; set; }
        public bool ManagePackages { get; set; }
        public bool ChangeRepositorySettings { get; set; }

        public List<TeamRepositoryResource> Repositories { get; set; }
    }

    public class TeamRepositoryResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}