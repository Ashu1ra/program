using DataAccessService.Application.DTO.Geo;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Application.Common.Mappers;

public static class PolygonMapper
{
    public static Polygon ToDomain(PolygonDto dto)
    {
        return Polygon.Create(
            dto.Points.Select(p => PointZ.Create(p.X, p.Y, p.Z))
        );
    }

    public static PolygonDto ToDto(Polygon domain)
    {
        return new PolygonDto(
            domain.Points
                .Select(p => new PointZDto(p.X, p.Y, p.Z))
                .ToList()
        );
    }
}