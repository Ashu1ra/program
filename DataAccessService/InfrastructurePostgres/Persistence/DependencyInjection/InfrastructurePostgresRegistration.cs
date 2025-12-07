using DataAccessService.Application.Interfaces;
using DataAccessService.Application.Interfaces.Repositories;
using DataAccessService.Application.Interfaces.Security;
using DataAccessService.InfrastructurePostgres.Persistence;
using DataAccessService.InfrastructurePostgres.Repositories;
using DataAccessService.InfrastructurePostgres.Security;
using DataAccessService.InfrastructurePostgres.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessService.InfrastructurePostgres.DependencyInjection;

public static class InfrastructurePostgresRegistration
{
    public static IServiceCollection AddInfrastructurePostgres(
        this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                config.GetConnectionString("DefaultConnection"),
                o => o.UseNetTopologySuite()));

        // Repositories
        services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Temporary ACL stub (replace later)
        services.AddScoped<IAccessControlService, AccessControlStub>();

        return services;
    }
}