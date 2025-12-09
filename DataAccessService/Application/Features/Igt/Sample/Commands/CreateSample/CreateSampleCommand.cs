using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Commands.CreateSample;

public record CreateSampleCommand(CreateSampleDto Dto)
    : IRequest<long>;