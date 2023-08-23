namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.AspNet;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityRoleSpecifications : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("role", "asp_net");
        builder.Property(role => role.Id)
            .HasColumnName("id");
        builder.Property(role => role.Name)
            .HasColumnName("name");
        builder.Property(role => role.NormalizedName)
            .HasColumnName("normalized_name");
        builder.Property(role => role.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");
    }
}