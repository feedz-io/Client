using System;

namespace Feedz.Client.Resources
{
    public class PersonalAccessTokenResource : IResource
    {
        public const string AccessLevelReadFeed = "ReadFeed";
        public const string AccessLevelWriteFeed = "WriteFeed";
        public const string AccessLevelEverything = "Everything";

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ServiceAccountId { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public string FriendlyId { get; set; }
        public string AccessLevel { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastUsed { get; set; }
        public DateTimeOffset Created { get; set; }
    }

    public class CreatePersonalAccessTokenRequest : IResource
    {
        public Guid? UserId { get; set; }
        public Guid? ServiceAccountId { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; } = PersonalAccessTokenResource.AccessLevelEverything;
        public DateTimeOffset? Expires { get; set; }
    }

    public class CreatePersonalAccessTokenResponse : PersonalAccessTokenResource
    {
        public string Token { get; set; }
    }

}