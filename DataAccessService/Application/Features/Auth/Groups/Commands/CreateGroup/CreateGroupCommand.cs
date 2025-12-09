using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Commands.CreateGroup;

public record CreateGroupCommand(CreateGroupListDto Dto) : IRequest<long>;