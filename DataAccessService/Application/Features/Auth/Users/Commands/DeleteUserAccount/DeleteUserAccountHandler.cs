using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.DeleteUserAccount;

public class DeleteUserAccountHandler : IRequestHandler<DeleteUserAccountCommand, Unit>
{
    private readonly IRepository<UserAccount> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteUserAccountHandler(
        IRepository<UserAccount> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteUserAccountCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("auth", "user_account", request.Id, ct);

        var user = await _repo.GetByIdAsync(request.Id, ct);
        if (user is null)
            throw new NotFoundException($"UserAccount {request.Id} not found");

        _repo.Remove(user);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}