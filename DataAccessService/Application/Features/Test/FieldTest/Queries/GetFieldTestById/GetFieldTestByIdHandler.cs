using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestById;

public class GetFieldTestByIdHandler
    : IRequestHandler<GetFieldTestByIdQuery, FieldTestResponseDto>
{
    private readonly IReadOnlyRepository<FieldTest> _repo;
    private readonly AclGuard _acl;

    public GetFieldTestByIdHandler(
        IReadOnlyRepository<FieldTest> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<FieldTestResponseDto> Handle(GetFieldTestByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("test", "field_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("FieldTest not found");

        return new FieldTestResponseDto(
            entity.Id,
            entity.LinkBoreholeInterval,
            entity.LinkListTestType,
            entity.Results ?? "{}",
            entity.TestDate,
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}
