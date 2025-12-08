using DataAccessService.Domain.Common;

namespace DataAccessService.Application.Abstractions.Persistence;

public interface IRepository<T> where T : AggregateRoot<long>
{
    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Remove(T entity);
}