namespace DataAccessService.Application.DTO.Test;

public record CreateLabTestDto(
    long LinkSample,
    long LinkListTestType,
    string Results,
    DateTime TestDate,
    string? Metadata
);