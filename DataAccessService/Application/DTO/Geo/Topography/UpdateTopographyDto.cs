namespace DataAccessService.Application.DTO.Geo;

public record UpdateTopographyDto(
    MultiPolygonDto? Area,
    byte[]? RasterFile,
    string? Metadata
);