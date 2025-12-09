using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;

namespace DataAccessService.Domain.Entities.Import
{
    public class RawFile : AggregateRoot<long>
    {
        public long LinkDataSource { get; private set; }
        public Name FileName { get; private set; }
        public long LinkListFileFormat { get; private set; }
        public SourceLink SourceLink { get; private set; }
        public byte[] FileData { get; private set; }
        public DateTime UploadAt { get; private set; } 
        public long OwnerUserId { get; private set; }

        private RawFile() { }

        public static RawFile Create(long linkDataSource, Name filename, long format, SourceLink sourceLink, byte[] data, long ownerUserId)
        {
            return new RawFile
            {
                LinkDataSource = linkDataSource,
                FileName = filename,
                LinkListFileFormat = format,
                SourceLink = sourceLink,
                FileData = data,
                UploadAt = DateTime.UtcNow,
                OwnerUserId = ownerUserId
            };
        }
    }
}