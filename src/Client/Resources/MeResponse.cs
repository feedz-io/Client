using System;
using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class MeResponse
    {
        public Guid? AccountId { get; set; }
        public required bool IsAuthenticated { get; set; }
        public required bool IsUser { get; set; }
        public required bool IsServiceAccount { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string AuthProviderPictureUri { get; set; }
        public required string PictureSource { get; set; }
        public required IReadOnlyList<Organisation> Organisations { get; set; }

        public class Organisation
        {
            public required Guid Id { get; set; }
            public required string Name { get; set; }
            public required string Slug { get; set; }
            public required bool IsDefault { get; set; }
            public required IReadOnlyList<Repository> Repositories { get; set; }
            public required bool ManageTeamsMembersAndServiceAccounts { get; set; }
            public required bool ManageSubscription { get; set; }
        }

        public class Repository
        {
            public required Guid Id { get; set; }
            public required string Slug { get; set; }
            public required string Name { get; set; }
            public required bool CanChangeRepositorySettings { get; set; }
        }

    }
}