using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.DeleteAclRule;

public record DeleteAclRuleCommand(long Id) : IRequest<Unit>;