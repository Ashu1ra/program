using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.UpdateGroup;

public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, Unit>
{
    private readonly IRepository<GroupList> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateGroupHandler(
        IRepository<GroupList> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "group_list", request.Id, ct);

        var group = await _repo.GetByIdAsync(request.Id, ct);
        if (group is null)
            throw new NotFoundException("Group not found");

        var dto = request.Dto;

        group.Rename(dto.Name);
        group.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}