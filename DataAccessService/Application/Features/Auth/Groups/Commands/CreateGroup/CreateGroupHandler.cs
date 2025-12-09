using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.CreateGroup;

public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, long>
{
    private readonly IRepository<GroupList> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateGroupHandler(
        IRepository<GroupList> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateGroupCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "group_list", null, ct);

        var dto = request.Dto;

        var group = GroupList.Create(dto.Name, dto.Description);

        await _repo.AddAsync(group, ct);
        await _uow.SaveChangesAsync(ct);

        return group.Id;
    }
}