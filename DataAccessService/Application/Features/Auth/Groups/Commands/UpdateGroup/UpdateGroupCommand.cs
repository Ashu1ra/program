using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.UpdateGroup;

public record UpdateGroupCommand(long Id, UpdateGroupListDto Dto) : IRequest<Unit>;