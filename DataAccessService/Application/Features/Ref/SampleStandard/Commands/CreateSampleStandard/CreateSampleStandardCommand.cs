using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Commands.CreateSampleStandard;

public record CreateSampleStandardCommand(CreateListSampleStandardDto Dto)
    : IRequest<long>;