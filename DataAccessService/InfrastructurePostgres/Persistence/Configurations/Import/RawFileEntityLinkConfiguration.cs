using DataAccessService.Domain.Entities.Import;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Import
{
    public class RawFileEntityLinkConfiguration : IEntityTypeConfiguration<RawFileEntityLink>
    {
        public void Configure(EntityTypeBuilder<RawFileEntityLink> builder)
        {
            builder.ToTable("raw_file_entity_link", "import");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkRawFile)
                .HasColumnName("link_raw_file")
                .IsRequired();

            builder.Property(x => x.EntitySchema)
                .HasColumnName("entity_schema")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.EntityName)
                .HasColumnName("entity_name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ObjectId)
                .HasColumnName("object_id")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz")
                .IsRequired();
        }
    }
}