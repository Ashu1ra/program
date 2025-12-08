using DataAccessService.Domain.Entities.Igt;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Igt
{
    public class BoreholeConfiguration : IEntityTypeConfiguration<Borehole>
    {
        public void Configure(EntityTypeBuilder<Borehole> builder)
        {
            builder.ToTable("borehole", "igt");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkSite)
                .HasColumnName("link_site")
                .IsRequired();

            builder.Property(x => x.Location)
                .HasColumnName("location")
                .HasColumnType("geometry(PointZ, 4326)")
                .HasConversion(new PointZConverter())
                .IsRequired();

            builder.Property(x => x.LinkListBoreholeType)
                .HasColumnName("link_list_borehole_type")
                .IsRequired();

            builder.Property(x => x.DepthMin)
                .HasColumnName("depth_min")
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(x => x.DepthMax)
                .HasColumnName("depth_max")
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(x => x.LinkListBoreholeStandard)
                .HasColumnName("link_list_borehole_standard")
                .IsRequired();

            builder.Property(x => x.DateStart)
                .HasColumnName("date_start")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.DateEnd)
                .HasColumnName("date_end")
                .HasColumnType("timestamptz");

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