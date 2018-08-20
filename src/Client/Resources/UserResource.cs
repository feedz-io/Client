using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class UserCreateResource : IResource
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        
        public bool AcceptTermsOfService { get; set; }
        public bool SubscribeToUpdateNotifications { get; set; }
    }

    public class UserResource : UserCreateResource
    {
        public Guid Id { get; set; }

        public bool EmailVerified { get; set; }

        public string AuthProviderPictureUri { get; set; }

        public PictureSource PictureSource { get; set; }
    }
}