using DataAccessService.Domain.Entities.Igt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Igt
{
    public class BoreholeIntervalConfiguration : IEntityTypeConfiguration<BoreholeInterval>
    {
        public void Configure(EntityTypeBuilder<BoreholeInterval> builder)
        {
            builder.ToTable("borehole_interval", "igt");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkBorehole)
                .HasColumnName("link_borehole")
                .IsRequired();

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

            builder.Property(x => x.LinkListBoreholeIntervalType)
                .HasColumnName("link_list_borehole_interval_type")
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