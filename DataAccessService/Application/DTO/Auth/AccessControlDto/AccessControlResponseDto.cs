namespace DataAccessService.Application.DTO.Auth;

public record AccessControlResponseDto(
    long Id,
    string EntitySchema,
    string EntityName,
    long? ObjectId,
    long? UserId,
    long? GroupId,
    long? RoleId,
    bool CanRead,
    bool CanWrite,
    bool CanDelete,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);