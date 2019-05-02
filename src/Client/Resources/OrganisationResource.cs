using System;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class OrganisationCreateResource : IResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }
    }

    public class OrganisationResource : OrganisationCreateResource
    {
        public Guid Id { get; set; }
        public string PlanId { get; set; }
        public int PlanStorageGigabytes { get; set; }
        public int PlanTransferGigabytes { get; set; }
        public DateTimeOffset BillingCycleAnchor { get; set; }
        public DateTimeOffset EndOfPeriod { get; set; }
        public bool RestrictToGoogleAuthentication { get; set; }
        public string RestrictedToDomain { get; set; }
    }
}