using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class AccessControl
    {
        public long Id { get; set; }

        public EntitySchemaName EntitySchema { get; set; }
        public EntityTableName EntityName { get; set; }
        public long? ObjectId { get; set; }

        public long? LinkUserAccount { get; set; }
        public long? LinkGroupList { get; set; }
        public long? LinkRoleList { get; set; }

        public AccessPermissions Permissions { get; set; }

        public string? Metadata { get; set; }
    }
}
