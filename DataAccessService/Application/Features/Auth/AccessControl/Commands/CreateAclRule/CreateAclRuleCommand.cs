using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.CreateAclRule;

public record CreateAclRuleCommand(CreateAccessControlDto Dto) : IRequest<long>;