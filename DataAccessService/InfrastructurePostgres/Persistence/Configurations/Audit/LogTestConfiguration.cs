using DataAccessService.InfrastructurePostgres.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Audit
{
    public class LogTestConfiguration : IEntityTypeConfiguration<LogTest>
    {
        public void Configure(EntityTypeBuilder<LogTest> builder)
        {
            builder.ToTable("log_test", "audit");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TestType)
                .HasColumnName("test_type")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.LinkTest)
                .HasColumnName("link_test");

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
