namespace DataAccessService.Application.DTO.Geo;

public record CreateTopographyDto(
    long LinkSite,
    long LinkDataSource,
    MultiPolygonDto Area,
    byte[] RasterFile,
    string? Metadata
);