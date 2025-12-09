using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Queries.GetAclRuleList;

public record GetAclRuleListQuery() : IRequest<IReadOnlyList<AccessControlResponseDto>>;