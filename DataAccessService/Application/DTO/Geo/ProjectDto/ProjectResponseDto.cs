namespace DataAccessService.Application.DTO.Geo;

public record ProjectResponseDto(
    long Id,
    long LinkListRegion,
    string Name,
    long LinkDataSource,
    PointZDto CenterLocation,
    MultiPolygonDto Area,
    DateTime DateStart,
    string? Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);