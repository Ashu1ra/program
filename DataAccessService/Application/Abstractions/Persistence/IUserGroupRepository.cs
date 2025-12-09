using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.Application.Abstractions.Persistence;

public interface IUserGroupRepository
{
    Task<IReadOnlyList<long>> GetGroupIdsByUserAsync(long userId, CancellationToken ct = default);
}