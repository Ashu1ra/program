using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Queries.GetTestTypeById;

public class GetTestTypeByIdHandler
    : IRequestHandler<GetTestTypeByIdQuery, ListTestTypeResponseDto>
{
    private readonly IReadOnlyRepository<ListTestType> _repo;
    private readonly AclGuard _acl;

    public GetTestTypeByIdHandler(
        IReadOnlyRepository<ListTestType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListTestTypeResponseDto> Handle(GetTestTypeByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_test_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListTestType {request.Id} not found");

        return new ListTestTypeResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Code.Value,
            entity.Name.Value,
            entity.Category.Value,
            entity.Description
        );
    }
}