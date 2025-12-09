using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Queries.GetAclRuleById;

public record GetAclRuleByIdQuery(long Id) : IRequest<AccessControlResponseDto>;
