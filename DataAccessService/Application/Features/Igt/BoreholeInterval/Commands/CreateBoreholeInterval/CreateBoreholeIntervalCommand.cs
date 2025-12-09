using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.CreateBoreholeInterval;

public record CreateBoreholeIntervalCommand(CreateBoreholeIntervalDto Dto)
    : IRequest<long>;