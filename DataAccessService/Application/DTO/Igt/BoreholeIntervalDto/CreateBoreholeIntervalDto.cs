namespace DataAccessService.Application.DTO.Igt;

public record CreateBoreholeIntervalDto(
    long LinkBorehole,
    DepthIntervalDto Interval,
    long LinkListBoreholeIntervalType,
    string? Metadata
);