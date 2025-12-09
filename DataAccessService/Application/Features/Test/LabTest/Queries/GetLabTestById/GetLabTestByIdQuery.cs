using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestById;

public record GetLabTestByIdQuery(long Id)
    : IRequest<LabTestResponseDto>;