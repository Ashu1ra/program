namespace DataAccessService.Application.DTO.Auth;

public record GroupListResponseDto(
    long Id,
    string Name,
    string? Description,
    long OwnerUserId
);