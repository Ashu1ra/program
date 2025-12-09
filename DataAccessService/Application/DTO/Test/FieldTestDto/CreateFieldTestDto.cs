namespace DataAccessService.Application.DTO.Test;

public record CreateFieldTestDto(
    long LinkBoreholeInterval,
    long LinkListTestType,
    string Results,
    DateTime TestDate,
    string? Metadata
);
