using DataAccessService.Domain.Entities.Test;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Test;

public interface ILabTestRepository : IRepository<LabTest>
{
}