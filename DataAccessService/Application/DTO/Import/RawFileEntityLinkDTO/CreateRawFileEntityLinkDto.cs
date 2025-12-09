namespace DataAccessService.Application.DTO.Import;

public record CreateRawFileEntityLinkDto(
    long RawFileId,
    string EntitySchema,
    string EntityName,
    long ObjectId
);