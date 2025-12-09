namespace DataAccessService.Application.DTO.Geo;

public record CreateProjectDto(
    long LinkListRegion,
    string Name,
    long LinkDataSource,
    PointZDto CenterLocation,
    MultiPolygonDto Area,
    string? Description
);
