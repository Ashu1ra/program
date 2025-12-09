using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestById;

public class GetLabTestByIdHandler
    : IRequestHandler<GetLabTestByIdQuery, LabTestResponseDto>
{
    private readonly IReadOnlyRepository<LabTest> _repo;
    private readonly AclGuard _acl;

    public GetLabTestByIdHandler(
        IReadOnlyRepository<LabTest> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<LabTestResponseDto> Handle(GetLabTestByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("test", "lab_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("LabTest not found");

        return new LabTestResponseDto(
            entity.Id,
            entity.LinkSample,
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