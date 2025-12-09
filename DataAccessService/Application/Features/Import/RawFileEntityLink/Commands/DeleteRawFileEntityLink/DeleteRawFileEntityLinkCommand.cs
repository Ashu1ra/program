using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Commands.DeleteRawFileEntityLink;

public record DeleteRawFileEntityLinkCommand(long Id)
    : IRequest<Unit>;