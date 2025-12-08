using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Geo
{
    public class CityModelConfiguration : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.ToTable("city_model", "geo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkSite)
                .HasColumnName("link_site")
                .IsRequired();

            builder.Property(x => x.Format)
                .HasColumnName("format")
                .HasColumnType("text")
                .HasConversion(new ModelFormatConverter())
                .IsRequired();

            builder.Property(x => x.FileData)
                .HasColumnName("file_data")
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
        }
    }
}
