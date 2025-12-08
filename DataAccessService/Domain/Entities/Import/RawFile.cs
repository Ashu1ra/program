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

        private readonly List<RawFileEntityLink> _entityLinks = new();
        public IReadOnlyCollection<RawFileEntityLink> EntityLinks => _entityLinks.AsReadOnly();

        private RawFile() { }

        public static RawFile Create(long linkDataSource, Name filename, long format, byte[] data, long ownerUserId)
        => new RawFile
        {
            LinkDataSource = linkDataSource,
            FileName = filename,
            LinkListFileFormat = format,
            FileData = data,
            UploadAt = DateTime.UtcNow,
            OwnerUserId = ownerUserId
        };

        public RawFileEntityLink LinkEntity(string schema, string entityName, long objectId)
        {
            var link = RawFileEntityLink.Create(Id, schema, entityName, objectId);
            _entityLinks.Add(link);
            return link;
        }

        public void UnlinkEntity(long objectId)
        {
            var link = _entityLinks.FirstOrDefault(x => x.ObjectId == objectId);
            if (link != null)
                _entityLinks.Remove(link);
        }

        public void ClearLinks()
        {
            _entityLinks.Clear();
        }
    }
}
