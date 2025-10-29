using System;

namespace Feedz.Client.Resources
{
    public class RepositoryStatisticsResponse
    {
        public required Guid Id { get; set; }
        public required int NumberOfPackages { get; set; }
        public required long TotalPackageBytes { get; set; }
    }
}