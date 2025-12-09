using DataAccessService.Domain.Common;

public class RawFileEntityLink : AggregateRoot<long>
{
    public long RawFileId { get; private set; }
    public string EntitySchema { get; private set; }
    public string EntityName { get; private set; }
    public long ObjectId { get; private set; }

    private RawFileEntityLink() { }

    public static RawFileEntityLink Create(long rawFileId, string schema, string entity, long objectId)
    {
        return new RawFileEntityLink
        {
            RawFileId = rawFileId,
            EntitySchema = schema,
            EntityName = entity,
            ObjectId = objectId
        };
    }
}
