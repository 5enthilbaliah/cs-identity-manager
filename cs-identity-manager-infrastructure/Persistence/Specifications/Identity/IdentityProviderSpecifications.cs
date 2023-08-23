namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Identity;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityProviderSpecifications : IEntityTypeConfiguration<IdentityProvider>
{
    public void Configure(EntityTypeBuilder<IdentityProvider> builder)
    {
        builder.Property(identityProvider => identityProvider.Id)
            .HasColumnName("id");
        builder.Property(identityProvider => identityProvider.Scheme)
            .HasColumnName("scheme");
        builder.Property(identityProvider => identityProvider.DisplayName)
            .HasColumnName("display_name");
        builder.Property(identityProvider => identityProvider.Enabled)
            .HasColumnName("enabled");
        builder.Property(identityProvider => identityProvider.Type)
            .HasColumnName("type");
        builder.Property(identityProvider => identityProvider.Properties)
            .HasColumnName("properties");
        builder.Property(identityProvider => identityProvider.Created)
            .HasColumnName("created");
        builder.Property(identityProvider => identityProvider.Updated)
            .HasColumnName("updated");
        builder.Property(identityProvider => identityProvider.LastAccessed)
            .HasColumnName("last_accessed");
        builder.Property(identityProvider => identityProvider.NonEditable)
            .HasColumnName("non_editable");
    }
}