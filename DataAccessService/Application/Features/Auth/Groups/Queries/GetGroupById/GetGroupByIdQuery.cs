using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Queries.GetGroupById;

public record GetGroupByIdQuery(long Id) : IRequest<GroupListResponseDto>;