namespace DataAccessService.Application.DTO.Geo;

public record SiteResponseDto(
    long Id,
    long LinkProject,
    string Name,
    PolygonDto Area,
    string? Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);