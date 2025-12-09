using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Geo.CityModels.Commands.DeleteCityModel;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.DeleteCityModel;

public class DeleteCityModelHandler
    : IRequestHandler<DeleteCityModelCommand, Unit>
{
    private readonly IRepository<CityModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteCityModelHandler(IRepository<CityModel> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteCityModelCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("geo", "city_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("CityModel not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}