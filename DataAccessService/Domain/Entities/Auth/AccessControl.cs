using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Auth
{
    public class AccessControl : AggregateRoot<long>
    {
        public string EntitySchema { get; private set; } = string.Empty;
        public string EntityName { get; private set; } = string.Empty;
        public long? ObjectId { get; private set; }

        public long? LinkUserAccount { get; private set; }
        public long? LinkGroupList { get; private set; }
        public long? LinkRoleList { get; private set; }

        public bool CanRead { get; private set; }
        public bool CanWrite { get; private set; }
        public bool CanDelete { get; private set; }

        public string? Metadata { get; private set; }

        private AccessControl() { }

        public static AccessControl Create(
            string entitySchema,
            string entityName,
            long? objectId,
            long? userId,
            long? groupId,
            long? roleId,
            bool canRead,
            bool canWrite,
            bool canDelete,
            string metadata = "{}"
        )
        {
            return new AccessControl
            {
                EntitySchema = entitySchema.ToLowerInvariant(),
                EntityName = entityName.ToLowerInvariant(),
                ObjectId = objectId,

                LinkUserAccount = userId,
                LinkGroupList = groupId,
                LinkRoleList = roleId,

                CanRead = canRead,
                CanWrite = canWrite,
                CanDelete = canDelete,

                Metadata = metadata
            };
        }

        public void UpdatePermissions(bool canRead, bool canWrite, bool canDelete)
        {
            CanRead = canRead;
            CanWrite = canWrite;
            CanDelete = canDelete;
        }

        public void UpdateMetadata(string metadata)
        {
            Metadata = metadata;
        }
    }
}