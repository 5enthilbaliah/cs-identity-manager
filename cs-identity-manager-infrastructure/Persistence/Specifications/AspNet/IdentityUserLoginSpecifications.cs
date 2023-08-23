namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityUserLoginSpecifications : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
    {
        builder.ToTable("user_login", "asp_net");
        builder.Property(login => login.LoginProvider)
            .HasColumnName("login_provider");
        builder.Property(login => login.ProviderKey)
            .HasColumnName("provider_key");
        builder.Property(login => login.ProviderDisplayName)
            .HasColumnName("provider_display_name");
        builder.Property(login => login.UserId)
            .HasColumnName("user_id");
    }
}