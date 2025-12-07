namespace DataAccessService.Application.DTO.Import;

public record UpdateDataSourceDto(
    string? Name,
    string? SourceLink,
    string? Description
);