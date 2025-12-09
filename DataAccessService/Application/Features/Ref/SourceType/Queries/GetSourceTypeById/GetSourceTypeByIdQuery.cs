using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Queries.GetSourceTypeById;

public record GetSourceTypeByIdQuery(long Id) : IRequest<ListSourceTypeResponseDto>;