using DataAccessService.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataAccessService.InfrastructurePostgres.Persistence;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly AppDbContext _db;

    public UserGroupRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<long>> GetGroupIdsByUserAsync(long userId, CancellationToken ct = default)
    {
        return await _db.UserGroups
            .Where(x => x.LinkUserAccount == userId)
            .Select(x => x.LinkGroupList)
            .ToListAsync(ct);
    }
}