using DataAccessService.InfrastructurePostgres.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Audit
{
    public class LogBoreholeConfiguration : IEntityTypeConfiguration<LogBorehole>
    {
        public void Configure(EntityTypeBuilder<LogBorehole> builder)
        {
            builder.ToTable("log_borehole", "audit");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkBorehole)
                .HasColumnName("link_borehole");

            builder.Property(x => x.OldData)
                .HasColumnName("old_data")
                .HasColumnType("json");

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