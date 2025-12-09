using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinkById;

public record GetRawFileEntityLinkByIdQuery(long Id)
    : IRequest<RawFileEntityLinkResponseDto>;