using DataAccessService.Domain.Entities.Import;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Import;

public interface IRawFileRepository : IRepository<RawFile>
{
    Task<IReadOnlyList<RawFile>> GetByDataSourceAsync(long dataSourceId);
}