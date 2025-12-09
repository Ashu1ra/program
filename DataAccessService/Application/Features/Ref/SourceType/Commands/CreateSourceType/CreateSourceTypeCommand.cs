using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Commands.CreateSourceType;

public record CreateSourceTypeCommand(CreateListSourceTypeDto Dto) : IRequest<long>;