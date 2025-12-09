using DataAccessService.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataAccessService.InfrastructurePostgres.Persistence;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _db;

    public UserRoleRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<long>> GetRoleIdsByUserAsync(long userId, CancellationToken ct = default)
    {
        return await _db.UserRoles
            .Where(x => x.LinkUserAccount == userId)
            .Select(x => x.LinkRoleList)
            .ToListAsync(ct);
    }
}