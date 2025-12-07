namespace DataAccessService.Application.DTO.Test;

public record UpdateLabTestDto(
    string? Results,
    DateTime? TestDate,
    string? Metadata
);