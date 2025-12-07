namespace DataAccessService.Application.DTO.Auth;

public record RoleListResponseDto(
    long Id,
    string Name,
    string? Description,
    long OwnerUserId
);