using DataAccessService.Domain.Entities.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Test
{
    public class LabTestConfiguration : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> builder)
        {
            builder.ToTable("lab_test", "test");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkSample)
                .HasColumnName("link_sample")
                .IsRequired();

            builder.Property(x => x.LinkListTestType)
                .HasColumnName("link_list_test_type")
                .IsRequired();

            builder.Property(x => x.Results)
                .HasColumnName("results")
                .HasColumnType("json")
                .IsRequired();

            builder.Property(x => x.TestDate)
                .HasColumnName("test_date")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("json");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamptz");

            builder.Property(x => x.OwnerUserId)
                .HasColumnName("owner_user_id")
                .IsRequired();
        }
    }
}