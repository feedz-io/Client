using System.IO;

namespace Feedz.Client.Plumbing
{
    internal class TemporaryFileStream : Stream
    {
        private readonly string _filename;
        private readonly FileStream _inner;

        public TemporaryFileStream(string filename, FileStream inner)
        {
            _filename = filename;
            _inner = inner;
        }

        public override void Flush() => _inner.Flush();

        public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);

        public override void SetLength(long value) => _inner.SetLength(value);

        public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);

        public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);

        public override bool CanRead => _inner.CanRead;
        public override bool CanSeek => _inner.CanSeek;
        public override bool CanWrite => _inner.CanWrite;
        public override long Length => _inner.Length;

        public override long Position
        {
            get => _inner.Position;
            set => _inner.Position = value;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                _inner.Dispose();
                File.Delete(_filename);
            }
            catch
            {}
        }
    }
}