using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Queries.GetFileFormatById;

public class GetFileFormatByIdHandler
    : IRequestHandler<GetFileFormatByIdQuery, ListFileFormatResponseDto>
{
    private readonly IReadOnlyRepository<ListFileFormat> _repo;
    private readonly AclGuard _acl;

    public GetFileFormatByIdHandler(
        IReadOnlyRepository<ListFileFormat> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ListFileFormatResponseDto> Handle(GetFileFormatByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_file_format", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"ListFileFormat {request.Id} not found");

        return new ListFileFormatResponseDto(
            entity.Id,
            entity.Mnemonic.Value,
            entity.Name.Value,
            entity.Metadata,
            entity.Description
        );
    }
}