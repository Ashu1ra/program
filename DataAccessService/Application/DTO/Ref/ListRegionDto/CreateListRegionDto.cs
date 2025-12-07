namespace DataAccessService.Application.DTO.Ref;

public record CreateListRegionDto(
    string Mnemonic,
    string Code,
    string Name
);