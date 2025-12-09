namespace DataAccessService.Application.DTO.Geo;

public record CreateCityModelDto(
    long LinkSite,
    string Format,
    MultiPolygonDto Area,
    byte[] FileData,
    string? Metadata
);
