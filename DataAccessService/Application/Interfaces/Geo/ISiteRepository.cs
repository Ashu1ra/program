using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Geo;

public interface ISiteRepository : IRepository<Site>
{
    Task<IReadOnlyList<Site>> GetByProjectAsync(long projectId);
}
