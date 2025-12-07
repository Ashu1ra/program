namespace DataAccessService.Application.DTO.Geo;

public record CreateTopographyDto(
    long SiteId,
    long DataSourceId,
    MultiPolygonDto Area,
    byte[] RasterFile,
    string Metadata,
    long OwnerUserId
);