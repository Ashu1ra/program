using DataAccessService.Domain.Common;

namespace DataAccessService.Application.Abstractions
{
    public interface IReadOnlyRepository<T> where T : AggregateRoot<long>
    {
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}