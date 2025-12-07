namespace DataAccessService.Application.DTO.Ref;

public record CreateListBoreholeTypeDto(
    string Mnemonic,
    string Name,
    string? Description
);