using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Feedz.Client.Resources
{
    public class AgentCreateResource : IResource
    {
        public string Name { get; set; }

        public string Thumbprint { get; set; }

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