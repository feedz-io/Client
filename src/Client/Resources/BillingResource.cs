using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class BillingResource : IResource
    {
        public required string Name { get; set; }

        public required string Line1 { get; set; }

        public required string Line2 { get; set; }

        public required string CityOrTown { get; set; }

        public required string State { get; set; }

        public required string PostalCode { get; set; }

        public required string Country { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }

        public required string PaymentToken { get; set; }

        public required string NameOnCard { get; set; }
        public required string Last4 { get; set; }
        public required string CardBrand { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
    }
}