using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Geo
{
    public class TopographyConfiguration : IEntityTypeConfiguration<Topography>
    {
        public void Configure(EntityTypeBuilder<Topography> builder)
        {
            builder.ToTable("topography", "geo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkSite)
                .HasColumnName("link_site")
                .IsRequired();

            builder.Property(x => x.LinkDataSource)
                .HasColumnName("link_data_source")
                .IsRequired();

            builder.Property(x => x.Area)
                .HasColumnName("area")
                .HasColumnType("geometry(MultiPolygon, 4326)")
                .HasConversion(new MultiPolygonConverter())
                .IsRequired();

            builder.Property(x => x.RasterFile)
                .HasColumnName("raster_file")
                .HasColumnType("bytea")
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