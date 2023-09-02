namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AmritaUserSpecifications : IEntityTypeConfiguration<AmritaUser>
{
    public void Configure(EntityTypeBuilder<AmritaUser> builder)
    {
        builder.ToTable("user", "asp_net");
        builder.Property(user => user.Id)
            .HasColumnName("id");
        builder.Property(user => user.UserName)
            .HasColumnName("user_name");
        builder.Property(user => user.NormalizedUserName)
            .HasColumnName("normalized_user_name");
        builder.Property(user => user.Email)
            .HasColumnName("email");
        builder.Property(user => user.NormalizedEmail)
            .HasColumnName("normalized_email");
        builder.Property(user => user.EmailConfirmed)
            .HasColumnName("email_confirmed");
        builder.Property(user => user.PasswordHash)
            .HasColumnName("password_hash");
        builder.Property(user => user.SecurityStamp)
            .HasColumnName("security_stamp");
        builder.Property(user => user.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");
        builder.Property(user => user.PhoneNumber)
            .HasColumnName("phone_number");
        builder.Property(user => user.PhoneNumberConfirmed)
            .HasColumnName("phone_number_confirmed");
        builder.Property(user => user.TwoFactorEnabled)
            .HasColumnName("two_factor_enabled");
        builder.Property(user => user.LockoutEnd)
            .HasColumnName("lockout_end");
        builder.Property(user => user.LockoutEnabled)
            .HasColumnName("lockout_enabled");
        builder.Property(user => user.AccessFailedCount)
            .HasColumnName("access_failed_count");
        builder.Property(user => user.FullName)
            .HasColumnName("full_name");
        builder.Property(user => user.ProfilePictureUrl)
            .HasColumnName("profile_picture_url")
            .HasMaxLength(512)
            .HasColumnType("nvarchar(512)");
        builder.Property(user => user.IsInternal)
            .HasColumnName("is_internal");
    }
}