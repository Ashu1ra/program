using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Queries.GetFileFormatById;

public record GetFileFormatByIdQuery(long Id) : IRequest<ListFileFormatResponseDto>;