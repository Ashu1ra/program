using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Queries.GetBoreholeStandardById;

public class GetBoreholeStandardByIdHandler
    : IRequestHandler<GetBoreholeStandardByIdQuery, ListBoreholeStandardResponseDto>
{
    private readonly IReadOnlyRepository<ListBoreholeStandard> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeStandardByIdHandler(
        IReadOnlyRepository<ListBoreholeStandard> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListBoreholeStandardResponseDto> Handle(GetBoreholeStandardByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_standard", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListBoreholeStandard {request.Id} not found");

        return new ListBoreholeStandardResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Description
        );
    }
}