namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityUserRoleSpecifications : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.ToTable("user_role", "asp_net");
        builder.Property(role => role.UserId)
            .HasColumnName("user_id");
        builder.Property(role => role.RoleId)
            .HasColumnName("role_id");
    }
}