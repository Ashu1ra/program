using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Queries.GetBoreholeTypeById;

public class GetBoreholeTypeByIdHandler
    : IRequestHandler<GetBoreholeTypeByIdQuery, ListBoreholeTypeResponseDto>
{
    private readonly IReadOnlyRepository<ListBoreholeType> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeTypeByIdHandler(
        IReadOnlyRepository<ListBoreholeType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListBoreholeTypeResponseDto> Handle(
        GetBoreholeTypeByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListBoreholeType {request.Id} not found");

        return new ListBoreholeTypeResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Description
        );
    }
}