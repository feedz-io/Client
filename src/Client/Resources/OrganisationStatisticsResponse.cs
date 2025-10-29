using System;

namespace Feedz.Client.Resources
{
    public class OrganisationStatisticsResponse
    {
        public Guid Id { get; set; }
        public int NumberOfPackages { get; set; }
        public long TotalPackageBytes { get; set; }
        public long QuotaUsedBytes { get; set; }
        public Transfer TransferredThisPeriod { get; set; }
        public Transfer TransferredPreviousPeriod { get; set; }
        public RepositoryStatisticsResponse[] Repositories { get; set; }

        public class Transfer
        {
            public int Uploads { get; set; }
            public long UploadBytes { get; set; }
            public int Downloads { get; set; }
            public long DownloadBytes { get; set; }
        }
    }
}