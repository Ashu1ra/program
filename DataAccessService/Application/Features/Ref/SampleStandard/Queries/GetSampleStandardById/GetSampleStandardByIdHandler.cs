using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Queries.GetSampleStandardById;

public class GetSampleStandardByIdHandler
    : IRequestHandler<GetSampleStandardByIdQuery, ListSampleStandardResponseDto>
{
    private readonly IReadOnlyRepository<ListSampleStandard> _repo;
    private readonly AclGuard _acl;

    public GetSampleStandardByIdHandler(
        IReadOnlyRepository<ListSampleStandard> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListSampleStandardResponseDto> Handle(
        GetSampleStandardByIdQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_sample_standard", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListSampleStandard {request.Id} not found");

        return new ListSampleStandardResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Description
        );
    }
}