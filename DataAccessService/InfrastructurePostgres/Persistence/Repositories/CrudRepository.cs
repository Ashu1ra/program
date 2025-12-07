using DataAccessService.Application.Interfaces.Repositories;
using DataAccessService.InfrastructurePostgres.Persistence;
using InfrastructurePostgres.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessService.InfrastructurePostgres.Repositories;

public class CrudRepository<T> : ICrudRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> _set;

    public CrudRepository(AppDbContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public Task<T?> GetByIdAsync(long id)
        => _set.FindAsync(id).AsTask();

    public Task<List<T>> GetAllAsync()
        => _set.ToListAsync();

    public Task AddAsync(T entity)
        => _set.AddAsync(entity).AsTask();

    public void Update(T entity)
        => _set.Update(entity);

    public void Delete(T entity)
        => _set.Remove(entity);
}