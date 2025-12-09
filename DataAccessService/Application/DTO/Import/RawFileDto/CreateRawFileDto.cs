namespace DataAccessService.Application.DTO.Import;

public record CreateRawFileDto(
    long LinkDataSource,
    string FileName,
    long LinkListFileFormat,
    string SourceLink,
    byte[] FileData
);