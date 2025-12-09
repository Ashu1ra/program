using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Commands.CreateRawFile;

public record CreateRawFileCommand(CreateRawFileDto Dto)
    : IRequest<long>;
