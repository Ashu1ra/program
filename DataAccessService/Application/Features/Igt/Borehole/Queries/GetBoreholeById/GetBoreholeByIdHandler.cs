using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeById;

public class GetBoreholeByIdHandler
    : IRequestHandler<GetBoreholeByIdQuery, BoreholeResponseDto>
{
    private readonly IReadOnlyRepository<Borehole> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeByIdHandler(IReadOnlyRepository<Borehole> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<BoreholeResponseDto> Handle(GetBoreholeByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "borehole", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Borehole not found");

        return new BoreholeResponseDto(
            entity.Id,
            entity.LinkSite,
            PointZMapper.ToDto(entity.Location),
            entity.LinkListBoreholeType,
            entity.DepthMin,
            entity.DepthMax,
            entity.LinkListBoreholeStandard,
            entity.DateStart,
            entity.DateEnd,
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}