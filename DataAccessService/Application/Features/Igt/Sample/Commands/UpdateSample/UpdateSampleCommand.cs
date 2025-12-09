using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Commands.UpdateSample;

public record UpdateSampleCommand(long Id, UpdateSampleDto Dto)
    : IRequest<Unit>;