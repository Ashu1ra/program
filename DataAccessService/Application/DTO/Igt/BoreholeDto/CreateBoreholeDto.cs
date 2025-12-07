namespace DataAccessService.Application.DTO.Igt;

using DataAccessService.Application.DTO.Geo;

public record CreateBoreholeDto(
    long SiteId,
    PointZDto Location,
    long BoreholeTypeId,
    double DepthMin,
    double DepthMax,
    long StandardId,
    DateTime DateStart,
    DateTime DateEnd,
    string Metadata,
    long OwnerUserId
);