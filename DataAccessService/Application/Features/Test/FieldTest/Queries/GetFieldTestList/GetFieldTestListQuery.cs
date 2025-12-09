using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestList;

public record GetFieldTestListQuery(long LinkBoreholeInterval)
    : IRequest<IReadOnlyList<FieldTestResponseDto>>;