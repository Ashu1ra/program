using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeList;
using DataAccessService.Application.Services.Security;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeList;

public class GetBoreholeListHandler
    : IRequestHandler<GetBoreholeListQuery, IReadOnlyList<BoreholeResponseDto>>
{
    private readonly IReadOnlyRepository<Borehole> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeListHandler(IReadOnlyRepository<Borehole> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<BoreholeResponseDto>> Handle(GetBoreholeListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "borehole", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(entity =>
            new BoreholeResponseDto(
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
            )
        ).ToList();
    }
}