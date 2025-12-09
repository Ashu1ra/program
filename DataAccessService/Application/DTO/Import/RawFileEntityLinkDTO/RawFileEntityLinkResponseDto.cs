namespace DataAccessService.Application.DTO.Import;

public record RawFileEntityLinkResponseDto(
    long Id,
    long RawFileId,
    string EntitySchema,
    string EntityName,
    long ObjectId
);