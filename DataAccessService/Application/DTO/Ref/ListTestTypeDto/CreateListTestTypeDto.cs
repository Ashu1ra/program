namespace DataAccessService.Application.DTO.Ref;

public record CreateListTestTypeDto(
    string Mnemonic,
    string Code,
    string Name,
    string Category,
    string? Description
);