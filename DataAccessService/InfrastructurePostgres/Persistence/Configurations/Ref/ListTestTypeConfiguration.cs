using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Ref
{
    public class ListTestTypeConfiguration : IEntityTypeConfiguration<ListTestType>
    {
        public void Configure(EntityTypeBuilder<ListTestType> builder)
        {
            builder.ToTable("list_test_type", "ref");

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

            builder.Property(x => x.Category)
                .HasColumnName("category")
                .HasConversion(
                    vo => vo.Value,
                    str => TestCategory.Create(str)
                )
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");
        }
    }
}
