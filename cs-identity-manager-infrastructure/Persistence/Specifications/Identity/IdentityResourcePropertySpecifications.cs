namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Identity;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityResourcePropertySpecifications : IEntityTypeConfiguration<IdentityResourceProperty>
{
    public void Configure(EntityTypeBuilder<IdentityResourceProperty> builder)
    {
        builder.Property(identityResource => identityResource.Id)
            .HasColumnName("id");
        builder.Property(identityResource => identityResource.IdentityResourceId)
            .HasColumnName("identity_resource_id");
        builder.Property(identityResource => identityResource.Key)
            .HasColumnName("key");
        builder.Property(identityResource => identityResource.Value)
            .HasColumnName("value");
    }
}