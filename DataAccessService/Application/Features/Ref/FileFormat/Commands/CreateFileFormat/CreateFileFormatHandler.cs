using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Commands.CreateFileFormat;

public class CreateFileFormatHandler : IRequestHandler<CreateFileFormatCommand, long>
{
    private readonly IRepository<ListFileFormat> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateFileFormatHandler(
        IRepository<ListFileFormat> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateFileFormatCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_file_format", null, ct);

        var dto = request.Dto;

        var entity = ListFileFormat.Create(
            Mnemonic.Create(dto.Mnemonic),
            Name.Create(dto.Name),
            dto.Metadata,
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}