using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class AgentCreateResource : IResource
    {
        public required string Name { get; set; }

        public required string Thumbprint { get; set; }

        public required string DnsName { get; set; }

        public required int Port { get; set; }

        public required string[] Roles { get; set; }
    }

    public class AgentResource : AgentCreateResource
    {
        public required Guid Id { get; set; }
        public required Guid RepositoryId { get; set; }
    }
}