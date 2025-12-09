namespace DataAccessService.Application.DTO.Test;

public record LabTestResponseDto(
    long Id,
    long LinkSample,
    long LinkListTestType,
    string Results,
    DateTime TestDate,
    string? Metadata,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);