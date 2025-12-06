using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Igt;

public interface IBoreholeRepository : IRepository<Borehole>
{
    Task<IReadOnlyList<Borehole>> GetBySiteAsync(long siteId);
}