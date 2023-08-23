namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityUserClaimSpecifications : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        builder.ToTable("user_claim", "asp_net");
        builder.Property(claim => claim.Id)
            .HasColumnName("id");
        builder.Property(claim => claim.UserId)
            .HasColumnName("user_id");
        builder.Property(claim => claim.ClaimType)
            .HasColumnName("claim_type");
        builder.Property(claim => claim.ClaimValue)
            .HasColumnName("claim_value");
    }
}