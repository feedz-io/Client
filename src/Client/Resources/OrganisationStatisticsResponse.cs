using System;

namespace Feedz.Client.Resources
{
    public class OrganisationStatisticsResponse
    {
        public required Guid Id { get; set; }
        public required int NumberOfPackages { get; set; }
        public required long TotalPackageBytes { get; set; }
        public required long QuotaUsedBytes { get; set; }
        public required Transfer TransferredThisPeriod { get; set; }
        public required Transfer TransferredPreviousPeriod { get; set; }
        public required RepositoryStatisticsResponse[] Repositories { get; set; }

        public class Transfer
        {
            public required int Uploads { get; set; }
            public required long UploadBytes { get; set; }
            public required int Downloads { get; set; }
            public required long DownloadBytes { get; set; }
        }
    }
}