using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Igt;

public interface IBoreholeIntervalRepository : IRepository<BoreholeInterval>
{
    Task<IReadOnlyList<BoreholeInterval>> GetByBoreholeAsync(long boreholeId);
}