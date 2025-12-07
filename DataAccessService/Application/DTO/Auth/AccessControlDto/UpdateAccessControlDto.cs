namespace DataAccessService.Application.DTO.Auth;

public record UpdateAccessControlDto(
    bool? CanRead,
    bool? CanWrite,
    bool? CanDelete,
    string? Metadata
);