using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Queries.GetSourceTypeById;

public class GetSourceTypeByIdHandler
    : IRequestHandler<GetSourceTypeByIdQuery, ListSourceTypeResponseDto>
{
    private readonly IReadOnlyRepository<ListSourceType> _repo;
    private readonly AclGuard _acl;

    public GetSourceTypeByIdHandler(
        IReadOnlyRepository<ListSourceType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListSourceTypeResponseDto> Handle(GetSourceTypeByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_source_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListSourceType {request.Id} not found");

        return new ListSourceTypeResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Description
        );
    }
}