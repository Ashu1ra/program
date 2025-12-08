using DataAccessService.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Auth
{
    public class GroupListConfiguration : IEntityTypeConfiguration<GroupList>
    {
        public void Configure(EntityTypeBuilder<GroupList> builder)
        {
            builder.ToTable("group_list", "auth");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");
        }
    }
}
