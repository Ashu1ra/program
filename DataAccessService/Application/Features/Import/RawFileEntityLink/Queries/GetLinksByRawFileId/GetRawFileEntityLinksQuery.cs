using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinks;

public record GetRawFileEntityLinksQuery(long RawFileId)
    : IRequest<IReadOnlyList<RawFileEntityLinkResponseDto>>;