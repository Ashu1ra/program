namespace DataAccessService.Application.DTO.Geo;

public record UpdateSiteDto(
    string? Name,
    MultiPolygonDto? Area,
    string? Description
);