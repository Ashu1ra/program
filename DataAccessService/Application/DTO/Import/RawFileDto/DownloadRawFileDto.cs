namespace DataAccessService.Application.DTO.Import;

public record DownloadRawFileDto(
    string FileName,
    string ContentType,
    byte[] FileData
);