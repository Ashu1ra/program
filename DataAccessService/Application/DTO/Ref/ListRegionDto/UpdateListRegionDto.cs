namespace DataAccessService.Application.DTO.Ref;

public record UpdateListRegionDto(
    string? Mnemonic,
    string? Code,
    string? Name
);