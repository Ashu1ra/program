namespace DataAccessService.Application.DTO.Ref;

public record CreateListSourceTypeDto(
    string Mnemonic,
    string Name,
    string? Description
);