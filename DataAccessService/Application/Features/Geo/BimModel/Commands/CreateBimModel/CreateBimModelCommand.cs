using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.CreateBimModel;

public record CreateBimModelCommand(CreateBimModelDto Dto)
    : IRequest<long>;