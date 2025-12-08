using DataAccessService.Domain.Entities.Igt;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Igt
{
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.ToTable("sample", "igt");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkBoreholeInterval)
                .HasColumnName("link_borehole_interval")
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName("number")
                .HasColumnType("text")
                .HasConversion(new CodeConverter())
                .IsRequired();

            builder.HasIndex(x => x.Number)
                .IsUnique()
                .HasDatabaseName("idx_sample_number_unique");

            builder.OwnsOne(
                x => x.Interval,
                interval =>
                {
                    interval.Property(p => p.From)
                        .HasColumnName("depth_from")
                        .HasColumnType("double precision")
                        .IsRequired();

                    interval.Property(p => p.To)
                        .HasColumnName("depth_to")
                        .HasColumnType("double precision")
                        .IsRequired();
                });

            builder.Property<double>("Depth")
                .HasColumnName("depth")
                .HasColumnType("double precision")
                .IsRequired();

            builder.HasIndex("Depth")
                .HasDatabaseName("idx_sample_depth");

            builder.Property(x => x.LinkListSampleStandard)
                .HasColumnName("link_list_sample_standard")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");

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
