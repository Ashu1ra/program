namespace DataAccessService.Application.DTO.Ref;

public record CreateListSampleStandardDto(
    string Mnemonic,
    string Name,
    string? Description
);