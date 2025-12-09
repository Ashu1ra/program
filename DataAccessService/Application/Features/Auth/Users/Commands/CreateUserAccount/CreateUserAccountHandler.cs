using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Domain.ValueObjects.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.CreateUserAccount;

public class CreateUserAccountHandler : IRequestHandler<CreateUserAccountCommand, long>
{
    private readonly IRepository<UserAccount> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;

    public CreateUserAccountHandler(
        IRepository<UserAccount> repo,
        AclGuard acl,
        IUnitOfWork uow,
        ICurrentUserService current)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
        _current = current;
    }

    public async Task<long> Handle(CreateUserAccountCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "user_account", null, ct);

        var dto = request.Dto;

        var entity = UserAccount.Create(
            UserLogin.Create(dto.Login),
            UserEmail.Create(dto.Email),
            PasswordHash.Create(dto.Password),
            FullName.Create(dto.FullName),
            dto.Metadata
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}