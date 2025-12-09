using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.Application.Abstractions.Persistence;

public interface IUserRoleRepository
{
    Task<IReadOnlyList<long>> GetRoleIdsByUserAsync(long userId, CancellationToken ct = default);
}