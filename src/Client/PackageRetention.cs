using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class PackageRetention : ApiEndpoint
    {
        internal PackageRetention(RepositoryScope repositories, IHttpClientWrapper apiClientWrapper)
            : base(repositories.RootUri + "/package-retention", apiClientWrapper)
        {
        }

        public Task<PackageRetentionConfigurationResource> Get()
            => ApiClientWrapper.Get<PackageRetentionConfigurationResource>(RootUri);

        public Task<PackageRetentionConfigurationResource> Update(PackageRetentionConfigurationResource configuration)
            => ApiClientWrapper.Update<PackageRetentionConfigurationResource>(RootUri, configuration);

        public Task<PackageRetentionDryRunResult> DryRun(PackageRetentionDryRunCommand command)
            => ApiClientWrapper.Create<PackageRetentionDryRunResult>($"{RootUri}/dry-run", command);
    }
}
