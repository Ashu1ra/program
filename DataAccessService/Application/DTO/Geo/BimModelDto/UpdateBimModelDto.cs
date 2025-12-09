namespace DataAccessService.Application.DTO.Geo;

public record UpdateBimModelDto(
    string? Format,
    MultiPolygonDto? Area,
    byte[]? FileData,
    string? Metadata
);