namespace DataAccessService.Application.DTO.Geo;

public record SiteResponseDto(
    long Id,
    long ProjectId,
    string Name,
    MultiPolygonDto Area,
    string? Description,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);