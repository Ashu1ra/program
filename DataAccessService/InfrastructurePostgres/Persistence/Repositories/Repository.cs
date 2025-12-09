using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DataAccessService.InfrastructurePostgres.Persistence;

public class Repository<T> : IRepository<T>
    where T : AggregateRoot<long>
{
    protected readonly AppDbContext _db;

    public Repository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _db.Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _db.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Remove(T entity)
    {
        _db.Set<T>().Remove(entity);
    }
}