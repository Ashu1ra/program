namespace DataAccessService.Application.DTO.Geo;

public record UpdateBimModelDto(
    string? Format,
    byte[]? FileData,
    string? Metadata
);