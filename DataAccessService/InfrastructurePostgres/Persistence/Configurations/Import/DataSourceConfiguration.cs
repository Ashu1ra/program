using DataAccessService.Domain.Entities.Import;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Import
{
    public class DataSourceConfiguration : IEntityTypeConfiguration<DataSource>
    {
        public void Configure(EntityTypeBuilder<DataSource> builder)
        {
            builder.ToTable("data_source", "import");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasConversion(new NameConverter())
                .IsRequired();

            builder.Property(x => x.LinkListSourceType)
                .HasColumnName("link_list_source_type")
                .IsRequired();

            builder.Property(x => x.SourceLink)
                .HasColumnName("source_link")
                .HasColumnType("text")
                .HasConversion(new SourceLinkConverter())
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(x => x.OwnerUserId)
                .HasColumnName("owner_user_id")
                .IsRequired();
        }
    }
}