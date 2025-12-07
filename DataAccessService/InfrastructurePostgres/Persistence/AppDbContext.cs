using Microsoft.EntityFrameworkCore;
using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Domain.Entities.Test;
using DataAccessService.Domain.Entities.Import;

namespace DataAccessService.InfrastructurePostgres.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}