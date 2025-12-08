using DataAccessService.Domain.Entities.Ref;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Ref
{
    public class ListRegionConfiguration : IEntityTypeConfiguration<ListRegion>
    {
        public void Configure(EntityTypeBuilder<ListRegion> builder)
        {
            builder.ToTable("list_region", "ref");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Mnemonic)
                .HasColumnName("mnemonic")
                .HasColumnType("text")
                .HasConversion(new MnemonicConverter())
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasColumnType("text")
                .HasConversion(new CodeConverter())
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasConversion(new NameConverter())
                .IsRequired();
        }
    }
}