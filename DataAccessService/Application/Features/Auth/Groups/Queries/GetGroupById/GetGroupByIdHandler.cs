using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Queries.GetGroupById;

public class GetGroupByIdHandler
    : IRequestHandler<GetGroupByIdQuery, GroupListResponseDto>
{
    private readonly IReadOnlyRepository<GroupList> _repo;
    private readonly AclGuard _acl;

    public GetGroupByIdHandler(
        IReadOnlyRepository<GroupList> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<GroupListResponseDto> Handle(GetGroupByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "group_list", request.Id, ct);

        var group = await _repo.GetByIdAsync(request.Id, ct);
        if (group is null)
            throw new NotFoundException($"Group {request.Id} not found");

        return new GroupListResponseDto(
            group.Id,
            group.Name,
            group.Description
        );
    }
}