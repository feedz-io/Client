using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class BillingResource : IResource
    {
        [Required]
        public string Name { get; set; }    
        
        [Required]
        public string Line1 { get; set; }
        
        public string Line2 { get; set; }   
        
        [Required]
        public string CityOrTown { get; set; }   
        
        [Required]
        public string State { get; set; }   
        
        [Required]
        public string PostalCode { get; set; }   
        
        [Required]
        public string Country { get; set; }   
        
        public string Phone { get; set; }   
        
        [Required]
        public string Email { get; set; }
        
        public string PaymentToken { get; set; }
        
        public string NameOnCard { get; set; }
        public string Last4 { get; set; }
        public string CardBrand { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
    }
}