using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedz.Client.Plumbing;
using Feedz.Client.Resources;

namespace Feedz.Client
{
    public class DeletedPackages : ApiEndpoint
    {
        internal DeletedPackages(RepositoryScope repositoryScope, IHttpClientWrapper apiClientWrapper)
            : base(repositoryScope.RootUri + "/deleted-packages", apiClientWrapper)
        {
        }

        public Task<IReadOnlyList<DeletedPackageResource>> List(
            string? q = null,
            DateTimeOffset? from = null,
            DateTimeOffset? to = null,
            int skip = 0,
            int take = 1000)
        {
            var url = UrlTemplate.Resolve(
                $"{RootUri}{{?q,from,to,skip,take}}",
                new { q, from, to, skip, take }
            );
            return ApiClientWrapper.List<DeletedPackageResource>(url);
        }

        public Task Restore(Guid id)
            => ApiClientWrapper.Update($"{RootUri}/restore/{id}", new { });
    }
}
