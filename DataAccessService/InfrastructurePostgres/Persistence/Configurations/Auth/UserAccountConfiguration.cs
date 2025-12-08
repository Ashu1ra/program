using DataAccessService.Domain.Entities.Auth;
using InfrastructurePostgres.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.Auth
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("user_account", "auth");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Login)
                .HasColumnName("login")
                .HasColumnType("text")
                .HasConversion(new UserLoginConverter())
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("text")
                .HasConversion(new UserEmailConverter())
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .HasColumnType("text")
                .HasConversion(new  PasswordHashConverter())
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasColumnType("text")
                .HasConversion(new FullNameConverter())
                .IsRequired();

            builder.Property(x => x.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("json");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            builder.Property(x => x.LastLogin)
                .HasColumnName("last_login")
                .HasColumnType("timestamptz");
        }
    }
}