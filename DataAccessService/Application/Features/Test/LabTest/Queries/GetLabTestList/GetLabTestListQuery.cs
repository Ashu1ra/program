using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestList;

public record GetLabTestListQuery(long LinkSample)
    : IRequest<IReadOnlyList<LabTestResponseDto>>;