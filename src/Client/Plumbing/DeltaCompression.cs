using System.IO;
using Feedz.Client.Resources;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace Feedz.Client.Plumbing
{
    internal class DeltaCompression
    {
        public static bool CreateDelta(IFeedzLogger log, Stream contents, PackageDeltaSignatureResult signatureResult, string deltaTempFile)
        {
            log.Info($"Calculating delta");
            var deltaBuilder = new DeltaBuilder();

            using (var signature = new MemoryStream(signatureResult.Signature))
            using (var deltaStream = File.Open(deltaTempFile, FileMode.Create, FileAccess.ReadWrite))
            {
                deltaBuilder.BuildDelta(
                    contents,
                    new SignatureReader(signature, new NullProgressReporter()),
                    new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream))
                );
            }
                
            var originalFileSize = contents.Length;
            var deltaFileSize = new FileInfo(deltaTempFile).Length;
            var ratio = deltaFileSize / (double) originalFileSize;

            if (ratio > 0.95)
            {
                log.Info($"The delta file ({deltaFileSize:n0} bytes) is more than 95% the size of the orginal file ({originalFileSize:n0} bytes)");
                return false;
            }

            log.Info($"The delta file ({deltaFileSize:n0} bytes) is {ratio:p2} the size of the orginal file ({originalFileSize:n0} bytes), uploading...");
            return true;
        }
    }
}
