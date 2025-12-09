namespace DataAccessService.Application.DTO.Igt;

public record SampleResponseDto(
    long Id,
    long LinkBoreholeInterval,
    string Number,
    DepthIntervalDto Interval,
    long LinkListSampleStandard,
    string? Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);