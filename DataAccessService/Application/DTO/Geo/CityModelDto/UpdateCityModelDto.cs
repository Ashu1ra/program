namespace DataAccessService.Application.DTO.Geo;

public record UpdateCityModelDto(
    string? Format,
    MultiPolygonDto? Area,
    byte[]? FileData,
    string? Metadata
);
