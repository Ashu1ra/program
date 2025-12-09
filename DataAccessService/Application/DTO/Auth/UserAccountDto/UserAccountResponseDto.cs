namespace DataAccessService.Application.DTO.Auth;

public record UserAccountResponseDto(
    long Id,
    string Login,
    string Email,
    string FullName,
    DateTime CreatedAt,
    DateTime? LastLogin,
    string Metadata
);