using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.UpdateAclRule;

public record UpdateAclRuleCommand(long Id, UpdateAccessControlDto Dto) : IRequest<Unit>;