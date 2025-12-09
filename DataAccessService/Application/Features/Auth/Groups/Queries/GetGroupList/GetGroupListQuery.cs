using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Queries.GetGroupList;

public record GetGroupListQuery() : IRequest<IReadOnlyList<GroupListResponseDto>>;