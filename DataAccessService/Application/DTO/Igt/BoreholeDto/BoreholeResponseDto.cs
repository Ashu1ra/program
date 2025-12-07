namespace DataAccessService.Application.DTO.Igt;

using DataAccessService.Application.DTO.Geo;

public record BoreholeResponseDto(
    long Id,
    long SiteId,
    PointZDto Location,
    long BoreholeTypeId,
    double DepthMin,
    double DepthMax,
    long StandardId,
    DateTime DateStart,
    DateTime DateEnd,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);