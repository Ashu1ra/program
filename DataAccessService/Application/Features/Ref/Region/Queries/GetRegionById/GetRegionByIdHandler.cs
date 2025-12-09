using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Queries.GetRegionById;

public class GetRegionByIdHandler
    : IRequestHandler<GetRegionByIdQuery, ListRegionResponseDto>
{
    private readonly IReadOnlyRepository<ListRegion> _repo;
    private readonly AclGuard _acl;

    public GetRegionByIdHandler(
        IReadOnlyRepository<ListRegion> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListRegionResponseDto> Handle(
        GetRegionByIdQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_region", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListRegion {request.Id} not found");

        return new ListRegionResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Code.Value,
            entity.Name.Value
        );
    }
}