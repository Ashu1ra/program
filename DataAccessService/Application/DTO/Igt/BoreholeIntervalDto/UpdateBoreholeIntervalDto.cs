namespace DataAccessService.Application.DTO.Igt;

public record UpdateBoreholeIntervalDto(
    DepthIntervalDto? Interval,
    string? Metadata,
    long? IntervalTypeId
);