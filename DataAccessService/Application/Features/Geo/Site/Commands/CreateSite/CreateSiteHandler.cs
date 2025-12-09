using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Sites.Commands.CreateSite;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Commands.CreateSite;

public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, long>
{
    private readonly IRepository<Site> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateSiteHandler(
        IRepository<Site> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateSiteCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "site", null, ct);

        var dto = request.Dto;

        var entity = Site.Create(
            dto.LinkProject,
            Name.Create(dto.Name),
            PolygonMapper.ToDomain(dto.Area),
            _current.UserId
        );

        entity.UpdateDescription(dto.Description);

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}