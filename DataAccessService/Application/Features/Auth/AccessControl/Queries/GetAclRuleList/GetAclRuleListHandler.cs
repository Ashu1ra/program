using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Features.Auth.Acl.Queries.GetAclRuleList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Queries.GetAclRuleList;

public class GetAclRuleListHandler
    : IRequestHandler<GetAclRuleListQuery, IReadOnlyList<AccessControlResponseDto>>
{
    private readonly IReadOnlyRepository<AccessControl> _repo;
    private readonly AclGuard _acl;

    public GetAclRuleListHandler(
        IReadOnlyRepository<AccessControl> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<AccessControlResponseDto>> Handle(GetAclRuleListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "access_control", null, ct);

        var rules = await _repo.GetAllAsync(ct);

        return rules.Select(a => new AccessControlResponseDto(
            a.Id,
            a.EntitySchema,
            a.EntityName,
            a.ObjectId,
            a.LinkUserAccount,
            a.LinkGroupList,
            a.LinkRoleList,
            a.CanRead,
            a.CanWrite,
            a.CanDelete,
            a.Metadata
        )).ToList();
    }
}