using DataAccessService.Application.DTO.Igt;
using DataAccessService.Domain.ValueObjects.Igt;

namespace DataAccessService.Application.Mappers;

public static class DepthIntervalMapper
{
    public static DepthIntervalDto ToDto(this DepthInterval value) =>
        new DepthIntervalDto(value.From, value.To);

    public static DepthInterval ToValueObject(this DepthIntervalDto dto) =>
        DepthInterval.Create(dto.From, dto.To);
}