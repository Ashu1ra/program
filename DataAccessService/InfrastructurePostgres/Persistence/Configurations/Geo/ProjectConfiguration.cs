using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Geo
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project", "geo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkListRegion)
                .HasColumnName("link_list_region")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasConversion(new NameConverter())
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.LinkDataSource)
                .HasColumnName("link_data_source")
                .IsRequired();

            builder.Property(x => x.CenterLocation)
                .HasColumnName("center_location")
                .HasColumnType("geometry(PointZ, 4326)")
                .HasConversion(new PointZConverter())
                .IsRequired();

            builder.Property(x => x.Area)
                .HasColumnName("area")
                .HasColumnType("geometry(MultiPolygon, 4326)")
                .HasConversion(new MultiPolygonConverter())
                .IsRequired();

            builder.Property(x => x.DateStart)
                .HasColumnName("date_start")
                .HasColumnType("timestamptz")
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