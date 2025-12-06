using DataAccessService.Domain.Common;

namespace DataAccessService.Application.Abstractions
{
    public interface IRepository<T> where T : AggregateRoot<long>
    {
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Update(T entity);

        void Remove(T entity);
    }
}