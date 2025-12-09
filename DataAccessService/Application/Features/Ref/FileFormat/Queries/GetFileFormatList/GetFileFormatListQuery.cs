using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Queries.GetFileFormatList;

public record GetFileFormatListQuery()
    : IRequest<IReadOnlyList<ListFileFormatResponseDto>>;