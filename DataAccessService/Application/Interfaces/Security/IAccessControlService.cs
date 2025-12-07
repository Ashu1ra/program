namespace DataAccessService.Application.Interfaces.Security;

public interface IAccessControlService
{
    bool CanRead(string schema, string table, long? objectId, long userId);
    bool CanWrite(string schema, string table, long? objectId, long userId);
    bool CanDelete(string schema, string table, long? objectId, long userId);
}