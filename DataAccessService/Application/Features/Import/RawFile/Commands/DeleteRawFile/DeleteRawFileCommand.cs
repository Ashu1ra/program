using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Commands.DeleteRawFile;

public record DeleteRawFileCommand(long Id) : IRequest<Unit>;
