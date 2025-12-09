namespace DataAccessService.Application.DTO.Auth;

public record UpdateUserAccountDto(
    string? Login,
    string? Email,
    string? Password,
    string? FullName,
    string? Metadata
);