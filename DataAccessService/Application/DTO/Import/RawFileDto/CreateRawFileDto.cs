namespace DataAccessService.Application.DTO.Import;

public record CreateRawFileDto(
    long DataSourceId,
    long FileFormatId,
    string Filename,
    byte[] FileData,
    string UploadedBy,
    long OwnerUserId
);