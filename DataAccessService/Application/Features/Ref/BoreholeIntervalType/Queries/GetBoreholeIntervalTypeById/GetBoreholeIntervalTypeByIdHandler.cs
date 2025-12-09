using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Queries.GetBoreholeIntervalTypeById;

public class GetBoreholeIntervalTypeByIdHandler
    : IRequestHandler<GetBoreholeIntervalTypeByIdQuery, ListBoreholeIntervalTypeResponseDto>
{
    private readonly IReadOnlyRepository<ListBoreholeIntervalType> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeIntervalTypeByIdHandler(
        IReadOnlyRepository<ListBoreholeIntervalType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListBoreholeIntervalTypeResponseDto> Handle(
        GetBoreholeIntervalTypeByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_interval_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListBoreholeIntervalType {request.Id} not found");

        return new ListBoreholeIntervalTypeResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Metadata,
            entity.Description
        );
    }
}