using DataAccessService.Application.Interfaces.Security;

namespace DataAccessService.InfrastructurePostgres.Security;

public class AccessControlStub : IAccessControlService
{
    public bool CanRead(string schema, string table, long? objectId, long userId) => true;
    public bool CanWrite(string schema, string table, long? objectId, long userId) => true;
    public bool CanDelete(string schema, string table, long? objectId, long userId) => true;
}