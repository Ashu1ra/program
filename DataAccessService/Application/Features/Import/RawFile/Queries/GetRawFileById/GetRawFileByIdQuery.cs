using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileById;

public record GetRawFileByIdQuery(long Id)
    : IRequest<RawFileResponseDto>;
