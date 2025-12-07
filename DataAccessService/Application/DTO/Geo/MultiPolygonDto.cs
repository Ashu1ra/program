namespace DataAccessService.Application.DTO.Geo;

public record MultiPolygonDto(
    List<List<List<PointZDto>>> Polygons
);