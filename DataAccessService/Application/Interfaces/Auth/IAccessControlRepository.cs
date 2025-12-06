using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Auth;

public interface IAccessControlRepository : IRepository<AccessControl>
{
    Task<IReadOnlyList<AccessControl>> GetForUserAsync(long userId);
    Task<IReadOnlyList<AccessControl>> GetForGroupAsync(long groupId);
    Task<IReadOnlyList<AccessControl>> GetForRoleAsync(long roleId);
}