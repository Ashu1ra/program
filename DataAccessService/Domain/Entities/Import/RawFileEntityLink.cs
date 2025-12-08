using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Import
{
    public class RawFileEntityLink : Entity<long>
    {
        public long LinkRawFile { get; private set; }
        public string EntitySchema { get; private set; } = string.Empty;
        public string EntityName { get; private set; } = string.Empty;
        public long ObjectId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private RawFileEntityLink(long rawFileId, string schema, string name, long objectId)
        {
            LinkRawFile = rawFileId;
            EntitySchema = schema;
            EntityName = name;
            ObjectId = objectId;
            CreatedAt = DateTime.UtcNow;
        }

        public static RawFileEntityLink Create(long rawFileId, string schema, string name, long objectId)
            => new RawFileEntityLink(rawFileId, schema, name, objectId);
    }
}