namespace DataAccessService.Application.DTO.Import;

public record RawFileResponseDto(
    long Id,
    long LinkDataSource,
    string FileName,
    long LinkListFileFormat,
    string SourceLink,
    DateTime UploadAt,
    long OwnerUserId
);
