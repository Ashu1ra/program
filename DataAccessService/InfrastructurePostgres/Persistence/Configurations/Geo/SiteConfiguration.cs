using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Geo
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("site", "geo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkProject)
                .HasColumnName("link_project")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasConversion(new NameConverter())
                .IsRequired();

            builder.Property(x => x.Area)
                .HasColumnName("area")
                .HasColumnType("geometry(Polygon, 4326)")
                .HasConversion(new PolygonConverter())
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
