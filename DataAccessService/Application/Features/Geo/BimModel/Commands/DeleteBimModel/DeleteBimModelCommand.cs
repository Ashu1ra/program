using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.DeleteBimModel;

public record DeleteBimModelCommand(long Id)
    : IRequest<Unit>;