using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.DownloadRawFile;

public record DownloadRawFileQuery(long Id)
    : IRequest<DownloadRawFileDto>;
