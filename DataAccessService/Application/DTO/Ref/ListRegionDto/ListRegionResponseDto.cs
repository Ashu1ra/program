namespace DataAccessService.Application.DTO.Ref;

public record ListRegionResponseDto(
    long Id,
    string Mnemonic,
    string Code,
    string Name
);