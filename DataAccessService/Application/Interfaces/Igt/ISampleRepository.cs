using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Igt;

public interface ISampleRepository : IRepository<Sample>
{
    Task<IReadOnlyList<Sample>> GetByIntervalAsync(long intervalId);
}