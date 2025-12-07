namespace DataAccessService.Application.DTO.Auth;

public record CreateAccessControlDto(
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
    long OwnerUserId
);