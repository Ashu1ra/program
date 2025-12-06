namespace DataAccessService.Application.DTO.Auth;

public record UserAccountResponseDto(
    long Id,
    string Login,
    string Email,
    string FullName,
    string Metadata,
    DateTime CreatedAt,
    DateTime LastLogin
);