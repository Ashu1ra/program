using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Queries.GetSourceTypeList;

public record GetSourceTypeListQuery() : IRequest<IReadOnlyList<ListSourceTypeResponseDto>>;