using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Commands.DeleteFileFormat;

public record DeleteFileFormatCommand(long Id) : IRequest<Unit>;