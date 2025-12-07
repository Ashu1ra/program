namespace DataAccessService.Application.DTO.Import;

public record CreateDataSourceDto(
    string Name,
    long SourceTypeId,
    string? SourceLink,
    string? Description,
    long OwnerUserId
);
