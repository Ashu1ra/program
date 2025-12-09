using DataAccessService.Application.DTO.Geo;

namespace DataAccessService.Application.DTO.Igt;

public record CreateBoreholeDto(
    long LinkSite,
    PointZDto Location,
    long LinkListBoreholeType,
    double DepthMin,
    double DepthMax,
    long LinkListBoreholeStandard,
    DateTime DateStart,
    DateTime? DateEnd,
    string? Metadata
);