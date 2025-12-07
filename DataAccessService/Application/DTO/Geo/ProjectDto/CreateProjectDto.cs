namespace DataAccessService.Application.DTO.Geo;

public record CreateProjectDto(
    string Name,
    long RegionId,
    long DataSourceId,
    PointZDto CenterLocation,
    MultiPolygonDto Area,
    DateTime DateStart,
    string Metadata,
    long OwnerUserId
);