using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Commands.CreateFileFormat;

public record CreateFileFormatCommand(CreateListFileFormatDto Dto) : IRequest<long>;