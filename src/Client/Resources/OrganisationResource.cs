using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class OrganisationCreateResource : IResource
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }
    }

    public class OrganisationResource : OrganisationCreateResource
    {
        public required Guid Id { get; set; }
        public required string PlanId { get; set; }
        public required string PlanBillingInterval { get; set; }
        public required int PlanStorageGigabytes { get; set; }
        public required int PlanTransferGigabytes { get; set; }
        public required DateTimeOffset BillingCycleAnchor { get; set; }
        public required DateTimeOffset EndOfPeriod { get; set; }
        public required bool RestrictToGoogleAuthentication { get; set; }
        public string? RestrictedToDomain { get; set; }
        public required bool IsNew { get; set; }
    }
}