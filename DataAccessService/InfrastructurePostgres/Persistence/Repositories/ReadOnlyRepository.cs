using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DataAccessService.InfrastructurePostgres.Persistence;

public class ReadOnlyRepository<T> : IReadOnlyRepository<T>
    where T : AggregateRoot<long>
{
    protected readonly AppDbContext _db;

    public ReadOnlyRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}