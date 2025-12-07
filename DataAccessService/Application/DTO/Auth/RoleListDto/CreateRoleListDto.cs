namespace DataAccessService.Application.DTO.Auth;

public record CreateRoleListDto(
    string Name,
    string? Description,
    long OwnerUserId
);