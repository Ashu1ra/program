using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Samples.Commands.CreateSample;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Commands.CreateSample;

public class CreateSampleHandler
    : IRequestHandler<CreateSampleCommand, long>
{
    private readonly IRepository<Sample> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateSampleHandler(
        IRepository<Sample> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateSampleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("igt", "sample", null, ct);

        var dto = request.Dto;

        var sample = Sample.Create(
            intervalId: dto.LinkBoreholeInterval,
            number: Code.Create(dto.Number),
            interval: dto.Interval.ToValueObject(),
            standardId: dto.LinkListSampleStandard,
            metadata: "{}",
            description: dto.Description,
            owner: _current.UserId
        );

        await _repo.AddAsync(sample, ct);
        await _uow.SaveChangesAsync(ct);

        return sample.Id;
    }
}