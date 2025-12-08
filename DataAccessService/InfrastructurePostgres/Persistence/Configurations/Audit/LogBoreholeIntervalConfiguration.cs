using DataAccessService.InfrastructurePostgres.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Audit
{
    public class LogBoreholeIntervalConfiguration : IEntityTypeConfiguration<LogBoreholeInterval>
    {
        public void Configure(EntityTypeBuilder<LogBoreholeInterval> builder)
        {
            builder.ToTable("log_borehole_interval", "audit");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkBoreholeInterval)
                .HasColumnName("link_borehole_interval");

            builder.Property(x => x.OldData)
                .HasColumnName("old_data")
                .HasColumnType("jsonb");

            builder.Property(x => x.OperationType)
                .HasColumnName("operation_type")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ChangedBy)
                .HasColumnName("changed_by");

            builder.Property(x => x.ChangedAt)
                .HasColumnName("changed_at")
                .HasColumnType("timestamptz");
        }
    }
}