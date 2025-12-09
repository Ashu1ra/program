using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.UpdateBimModel;

public record UpdateBimModelCommand(long Id, UpdateBimModelDto Dto)
    : IRequest<Unit>;