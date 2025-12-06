using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;

namespace DataAccessService.Domain.Entities.Import
{
    public class RawFile
    {
        public long Id { get; set; }
        public long LinkDataSource { get; set; }
        public Name FileName { get; set; }
        public long LinkListFileFormat { get; set; }
        public SourceLink SourceLink { get; set; }
        public byte[] FileData { get; set; }
        public DateTime UploadAt { get; set; } 
        public long OwnerUserId { get; set; }
    }
}
