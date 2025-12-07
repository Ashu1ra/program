namespace DataAccessService.Application.DTO.Geo;

public record ProjectResponseDto(
    long Id,
    string Name,
    long RegionId,
    long DataSourceId,
    PointZDto CenterLocation,
    MultiPolygonDto Area,
    DateTime DateStart,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);