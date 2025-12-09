namespace DataAccessService.Application.DTO.Geo;

public record CreateBimModelDto(
    long LinkSite,
    string Format,
    MultiPolygonDto Area,
    byte[] FileData,
    string? Metadata
);