namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityRoleClaimSpecifications : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        builder.ToTable("role_claim", "asp_net");
        builder.Property(claim => claim.Id)
            .HasColumnName("id");
        builder.Property(claim => claim.RoleId)
            .HasColumnName("role_id");
        builder.Property(claim => claim.ClaimType)
            .HasColumnName("claim_type");
        builder.Property(claim => claim.ClaimValue)
            .HasColumnName("claim_value");
    }
}