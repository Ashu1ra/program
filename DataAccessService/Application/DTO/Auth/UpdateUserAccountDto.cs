namespace DataAccessService.Application.DTO.Auth;

public record UpdateUserAccountDto(
    string? Email,
    string? Password,
    string? FullName,
    string? Metadata
);