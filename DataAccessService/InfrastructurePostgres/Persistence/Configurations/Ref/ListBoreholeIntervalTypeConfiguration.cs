using DataAccessService.Domain.Entities.Ref;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Ref
{
    public class ListBoreholeIntervalTypeConfiguration : IEntityTypeConfiguration<ListBoreholeIntervalType>
    {
        public void Configure(EntityTypeBuilder<ListBoreholeIntervalType> builder)
        {
            builder.ToTable("list_borehole_interval_type", "ref");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Mnemonic)
                .HasColumnName("mnemonic")
                .HasColumnType("text")
                .HasConversion(new MnemonicConverter())
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasConversion(new NameConverter())
                .IsRequired();

            builder.Property(x => x.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("jsonb");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");
        }
    }
}