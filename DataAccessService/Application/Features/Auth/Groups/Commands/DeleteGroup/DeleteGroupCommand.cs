using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.DeleteGroup;

public record DeleteGroupCommand(long Id) : IRequest<Unit>;