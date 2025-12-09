using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Auth.Acl.Commands.DeleteAclRule;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.DeleteAclRule;

public class DeleteAclRuleHandler : IRequestHandler<DeleteAclRuleCommand, Unit>
{
    private readonly IRepository<AccessControl> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteAclRuleHandler(
        IRepository<AccessControl> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteAclRuleCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("auth", "access_control", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ACL Rule not found");

        _repo.Remove(entity);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}