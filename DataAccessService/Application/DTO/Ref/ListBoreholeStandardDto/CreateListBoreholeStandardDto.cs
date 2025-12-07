namespace DataAccessService.Application.DTO.Ref;

public record CreateListBoreholeStandardDto(
    string Mnemonic,
    string Name,
    string? Description
);