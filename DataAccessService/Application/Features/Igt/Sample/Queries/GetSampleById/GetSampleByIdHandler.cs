using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleById;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleById;

public class GetSampleByIdHandler
    : IRequestHandler<GetSampleByIdQuery, SampleResponseDto>
{
    private readonly IReadOnlyRepository<Sample> _repo;
    private readonly AclGuard _acl;

    public GetSampleByIdHandler(
        IReadOnlyRepository<Sample> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<SampleResponseDto> Handle(GetSampleByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "sample", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Sample not found");

        return new SampleResponseDto(
            entity.Id,
            entity.LinkBoreholeInterval,
            entity.Number.Value,
            entity.Interval.ToDto(),
            entity.LinkListSampleStandard,
            entity.Description,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}