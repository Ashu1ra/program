using DataAccessService.Domain.ValueObjects.Geo;
using DataAccessService.Application.DTO.Geo;

public static class PointZMapper
{
    public static PointZ ToDomain(PointZDto dto)
        => PointZ.Create(dto.X, dto.Y, dto.Z);

    public static PointZDto ToDto(PointZ domain)
        => new(domain.X, domain.Y, domain.Z);
}