using System;
using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class TeamResource : IResource
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid OrganisationId { get; set; }
        public required bool IsBuiltIn { get; set; }

        public required bool ViewTeamsMembersAndServiceAccounts { get; set; }
        public required bool ManageTeamsMembersAndServiceAccounts { get; set; }
        public required bool ManageOrganisation { get; set; }
        public required bool ManageSubscription { get; set; }
        public required bool ViewEvents { get; set; }
        public required bool AddRepositories { get; set; }
        public required bool RemoveRepositories { get; set; }

        public required bool AllRepositories { get; set; }
        public required bool ManagePackages { get; set; }
        public required bool ChangeRepositorySettings { get; set; }

        public required List<TeamRepositoryResource> Repositories { get; set; }
    }

    public class TeamRepositoryResource
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Slug { get; set; }
    }
}