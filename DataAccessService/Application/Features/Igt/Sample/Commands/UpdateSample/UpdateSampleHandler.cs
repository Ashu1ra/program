using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Samples.Commands.UpdateSample;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Commands.UpdateSample;

public class UpdateSampleHandler : IRequestHandler<UpdateSampleCommand, Unit>
{
    private readonly IRepository<Sample> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateSampleHandler(
        IRepository<Sample> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateSampleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("igt", "sample", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Sample not found");

        var dto = request.Dto;

        entity.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}