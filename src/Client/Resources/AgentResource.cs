using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class AgentCreateResource : IResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Thumbprint { get; set; }

        [Required]
        public string DnsName { get; set; }

        public int Port { get; set; }
        
        public string[] Roles { get; set; }
    }

    public class AgentResource : AgentCreateResource
    {
        public Guid Id { get; set; }
        public Guid RepositoryId { get; set; }
    }
}