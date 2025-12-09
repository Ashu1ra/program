namespace DataAccessService.Application.DTO.Geo;

public record CreateSiteDto(
    long LinkProject,
    string Name,
    PolygonDto Area,
    string? Description
);