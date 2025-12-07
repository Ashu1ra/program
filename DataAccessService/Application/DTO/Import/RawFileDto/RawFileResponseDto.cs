namespace DataAccessService.Application.DTO.Import;

public record RawFileResponseDto(
    long Id,
    long DataSourceId,
    long FileFormatId,
    string Filename,
    string UploadedBy,
    DateTime UploadAt,
    long OwnerUserId
);