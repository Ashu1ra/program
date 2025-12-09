using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Commands.UpdateFileFormat;

public record UpdateFileFormatCommand(long Id, UpdateListFileFormatDto Dto) : IRequest<Unit>;