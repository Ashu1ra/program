namespace DataAccessService.Application.DTO.Igt;

public record CreateSampleDto(
    long LinkBoreholeInterval,
    string Number,
    DepthIntervalDto Interval,
    long LinkListSampleStandard,
    string? Description
);