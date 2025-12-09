using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.DeleteGroup;

public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, Unit>
{
    private readonly IRepository<GroupList> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteGroupHandler(
        IRepository<GroupList> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("auth", "group_list", request.Id, ct);

        var group = await _repo.GetByIdAsync(request.Id, ct);
        if (group is null)
            throw new NotFoundException("Group not found");

        _repo.Remove(group);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}