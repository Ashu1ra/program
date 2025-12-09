using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Commands.CreateRawFileEntityLink;

public record CreateRawFileEntityLinkCommand(CreateRawFileEntityLinkDto Dto)
    : IRequest<long>;