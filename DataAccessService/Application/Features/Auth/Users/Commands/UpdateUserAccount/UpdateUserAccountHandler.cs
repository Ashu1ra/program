using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Domain.ValueObjects.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.UpdateUserAccount;

public class UpdateUserAccountHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
{
    private readonly IRepository<UserAccount> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateUserAccountHandler(
        IRepository<UserAccount> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "user_account", request.Id, ct);

        var user = await _repo.GetByIdAsync(request.Id, ct);
        if (user is null)
            throw new NotFoundException($"UserAccount {request.Id} not found");

        var dto = request.Dto;

        user.ChangeLogin(UserLogin.Create(dto.Login));
        user.ChangeEmail(UserEmail.Create(dto.Email));
        user.UpdateFullName(FullName.Create(dto.FullName));
        user.UpdateMetadata(dto.Metadata);

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            user.ChangePassword(PasswordHash.Create(dto.Password));
        }

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
