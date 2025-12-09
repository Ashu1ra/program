namespace DataAccessService.Application.DTO.Geo;

public record UpdateProjectDto(
    string Name,
    PointZDto CenterLocation,
    MultiPolygonDto Area,
    string? Description
);
