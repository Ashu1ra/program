namespace DataAccessService.Application.DTO.Ref;

public record UpdateListFileFormatDto(
    string? Name,
    string? Metadata,
    string? Description
);