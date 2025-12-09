using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileList;

public record GetRawFileListQuery()
    : IRequest<IReadOnlyList<RawFileResponseDto>>;