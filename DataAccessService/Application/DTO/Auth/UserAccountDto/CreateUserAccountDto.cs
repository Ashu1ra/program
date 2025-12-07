namespace DataAccessService.Application.DTO.Auth;

public record CreateUserAccountDto(
    string Login,
    string Email,
    string Password,
    string FullName,
    string Metadata,
    long OwnerUserId
);