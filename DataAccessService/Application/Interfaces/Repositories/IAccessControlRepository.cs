using System.Threading.Tasks;

namespace DataAccessService.Application.Interfaces.Repositories;

public interface IAccessControlRepository
{
    Task<(bool CanRead, bool CanWrite, bool CanDelete)> 
        GetPermissionsAsync(
        string schema, 
        string table, 
        long? objectId, 
        long userId
        );
}