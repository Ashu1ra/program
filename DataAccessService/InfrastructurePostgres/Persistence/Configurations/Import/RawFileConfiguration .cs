using DataAccessService.Domain.Entities.Import;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Import
{
    public class RawFileConfiguration : IEntityTypeConfiguration<RawFile>
    {
        public void Configure(EntityTypeBuilder<RawFile> builder)
        {
            builder.ToTable("raw_file", "import");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LinkDataSource)
                .HasColumnName("link_data_source")
                .IsRequired();

            builder.Property(x => x.FileName)
                .HasColumnName("filename")
                .HasColumnType("text")
                .HasConversion(new NameConverter())
                .IsRequired();

            builder.Property(x => x.LinkListFileFormat)
                .HasColumnName("link_list_file_format")
                .IsRequired();

            builder.Property(x => x.FileData)
                .HasColumnName("file_data")
                .HasColumnType("bytea")
                .IsRequired();

            builder.Property(x => x.UploadAt)
                .HasColumnName("upload_at")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.OwnerUserId)
                .HasColumnName("owner_user_id")
                .IsRequired();
        }
    }
}