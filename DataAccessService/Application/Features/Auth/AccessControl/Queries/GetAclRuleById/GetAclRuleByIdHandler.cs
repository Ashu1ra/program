using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Queries.GetAclRuleById;

public class GetAclRuleByIdHandler
    : IRequestHandler<GetAclRuleByIdQuery, AccessControlResponseDto>
{
    private readonly IReadOnlyRepository<AccessControl> _repo;
    private readonly AclGuard _acl;

    public GetAclRuleByIdHandler(
        IReadOnlyRepository<AccessControl> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<AccessControlResponseDto> Handle(GetAclRuleByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "access_control", request.Id, ct);

        var acl = await _repo.GetByIdAsync(request.Id, ct);
        if (acl is null)
            throw new NotFoundException($"AccessControl rule {request.Id} not found");

        return new AccessControlResponseDto(
            acl.Id,
            acl.EntitySchema,
            acl.EntityName,
            acl.ObjectId,
            acl.LinkUserAccount,
            acl.LinkGroupList,
            acl.LinkRoleList,
            acl.CanRead,
            acl.CanWrite,
            acl.CanDelete,
            acl.Metadata
        );
    }
}