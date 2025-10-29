using System;
using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class MeResponse
    {
        public Guid? AccountId { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsUser { get; set; }
        public bool IsServiceAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AuthProviderPictureUri { get; set; }
        public string PictureSource { get; set; }
        public IReadOnlyList<Organisation> Organisations { get; set; }

        public class Organisation
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public bool IsDefault { get; set; }
            public IReadOnlyList<Repository> Repositories { get; set; }
            public bool ManageTeamsMembersAndServiceAccounts { get; set; }
            public bool ManageSubscription { get; set; }
        }

        public class Repository
        {
            public Guid Id { get; set; }
            public string Slug { get; set; }
            public string Name { get; set; }
            public bool CanChangeRepositorySettings { get; set; }
        }

    }
}