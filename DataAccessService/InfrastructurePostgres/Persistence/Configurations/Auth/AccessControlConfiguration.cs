using DataAccessService.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Auth
{
    public class AccessControlConfiguration : IEntityTypeConfiguration<AccessControl>
    {
        public void Configure(EntityTypeBuilder<AccessControl> builder)
        {
            builder.ToTable("access_control", "auth");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.EntitySchema)
                .HasColumnName("entity_schema")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.EntityName)
                .HasColumnName("entity_name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ObjectId)
                .HasColumnName("object_id");

            builder.Property(x => x.LinkUserAccount)
                .HasColumnName("link_user_account");

            builder.Property(x => x.LinkGroupList)
                .HasColumnName("link_group_list");

            builder.Property(x => x.LinkRoleList)
                .HasColumnName("link_role_list");

            builder.Property(x => x.CanRead)
                .HasColumnName("can_read");

            builder.Property(x => x.CanWrite)
                .HasColumnName("can_write");

            builder.Property(x => x.CanDelete)
                .HasColumnName("can_delete");

            builder.Property(x => x.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("jsonb")
                .IsRequired(false);
        }
    }
}
