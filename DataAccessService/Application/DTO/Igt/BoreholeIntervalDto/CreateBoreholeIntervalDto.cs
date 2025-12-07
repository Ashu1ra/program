namespace DataAccessService.Application.DTO.Igt;

public record CreateBoreholeIntervalDto(
    long BoreholeId,
    DepthIntervalDto Interval,
    long IntervalTypeId,
    string Metadata,
    long OwnerUserId
);