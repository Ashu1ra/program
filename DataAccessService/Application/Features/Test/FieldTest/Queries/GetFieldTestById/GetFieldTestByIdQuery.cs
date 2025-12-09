using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestById;

public record GetFieldTestByIdQuery(long Id)
    : IRequest<FieldTestResponseDto>;
