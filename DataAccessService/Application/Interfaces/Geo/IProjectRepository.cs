using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Geo;

public interface IProjectRepository : IRepository<Project>
{
    Task<IReadOnlyList<Project>> GetByRegionAsync(long regionId);
}