using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class AccessControl : AggregateRoot<long>
    {
        public EntitySchemaName EntitySchema { get; private set; }
        public EntityTableName EntityName { get; private set; }
        public long? ObjectId { get; private set; }

        public long? LinkUserAccount { get; private set; }
        public long? LinkGroupList { get; private set; }
        public long? LinkRoleList { get; private set; }

        public AccessPermissions Permissions { get; private set; }

        public string? Metadata { get; private set; }

        private AccessControl() { }

        public static AccessControl Create(EntitySchemaName schema, EntityTableName table, long? objectId,
            long? userId, long? groupId, long? roleId, AccessPermissions permissions, string metadata = "{}")
        {
            return new AccessControl
            {
                EntitySchema = schema,
                EntityName = table,
                ObjectId = objectId,
                LinkUserAccount = userId,
                LinkGroupList = groupId,
                LinkRoleList = roleId,
                Permissions = permissions,
                Metadata = metadata
            };
        }

        public void UpdatePermissions(bool read, bool write, bool delete)
        {
            Permissions = AccessPermissions.Create(read, write, delete);
        }

        public void UpdateMetadata(string metadata) => Metadata = metadata;
    }
}