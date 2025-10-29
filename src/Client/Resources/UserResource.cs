using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class UserCreateResource : IResource
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public required bool AcceptTermsOfService { get; set; }
        public required bool SubscribeToUpdateNotifications { get; set; }
    }

    public class UserResource : UserCreateResource
    {
        public required Guid Id { get; set; }

        public required bool EmailVerified { get; set; }

        public string? AuthProviderPictureUri { get; set; }

        public string? PictureSource { get; set; }
    }
}