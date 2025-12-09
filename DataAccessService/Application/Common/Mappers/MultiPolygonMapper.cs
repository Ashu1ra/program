using DataAccessService.Application.DTO.Geo;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Application.Common.Mappers;

public static class MultiPolygonMapper
{
    /// <summary>
    /// DTO → Domain
    /// </summary>
    public static MultiPolygon ToDomain(MultiPolygonDto dto)
    {
        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        return MultiPolygon.Create(
            dto.Polygons.Select(poly =>
                poly.Select(contour =>
                    contour.Select(pt =>
                        PointZ.Create(pt.X, pt.Y, pt.Z)
                    )
                )
            )
        );
    }

    /// <summary>
    /// Domain → DTO
    /// </summary>
    public static MultiPolygonDto ToDto(MultiPolygon domain)
    {
        if (domain is null)
            throw new ArgumentNullException(nameof(domain));

        return new MultiPolygonDto(
            domain.Polygons
                .Select(poly =>
                    poly.Select(contour =>
                        contour.Select(pt =>
                            new PointZDto(pt.X, pt.Y, pt.Z)
                        ).ToList()
                    ).ToList()
                ).ToList()
        );
    }
}