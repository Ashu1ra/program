namespace DataAccessService.Application.DTO.Ref;

public record CreateListBoreholeIntervalTypeDto(
    string Mnemonic,
    string Name,
    string Metadata,
    string? Description
);