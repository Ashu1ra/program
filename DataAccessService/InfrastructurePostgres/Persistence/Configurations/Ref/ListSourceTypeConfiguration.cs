using DataAccessService.Domain.Entities.Ref;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Ref
{
    public class ListSourceTypeConfiguration : IEntityTypeConfiguration<ListSourceType>
    {
        public void Configure(EntityTypeBuilder<ListSourceType> builder)
        {
            builder.ToTable("list_source_type", "ref");

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

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");
        }
    }
}
