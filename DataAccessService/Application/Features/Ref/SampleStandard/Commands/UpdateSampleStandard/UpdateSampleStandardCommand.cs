using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Commands.UpdateSampleStandard;

public record UpdateSampleStandardCommand(long Id, UpdateListSampleStandardDto Dto)
    : IRequest<Unit>;