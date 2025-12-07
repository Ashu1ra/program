namespace DataAccessService.Application.DTO.Auth;

public record CreateGroupListDto(
    string Name,
    string? Description,
    long OwnerUserId
);