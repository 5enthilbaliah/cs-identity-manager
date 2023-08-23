namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityUserTokenSpecifications : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.ToTable("user_token", "asp_net");
        builder.Property(token => token.UserId)
            .HasColumnName("user_id");
        builder.Property(token => token.LoginProvider)
            .HasColumnName("login_provider");
        builder.Property(token => token.Name)
            .HasColumnName("name");
        builder.Property(token => token.Value)
            .HasColumnName("value");
    }
}