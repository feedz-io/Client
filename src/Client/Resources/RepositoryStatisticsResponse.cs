using System;

namespace Feedz.Client.Resources
{
    public class RepositoryStatisticsResponse
    {
        public Guid Id { get; set; }
        public int NumberOfPackages { get; set; }
        public long TotalPackageBytes { get; set; }
    }
}