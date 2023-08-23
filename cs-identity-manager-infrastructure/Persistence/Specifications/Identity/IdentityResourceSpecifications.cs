namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Identity;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityResourceSpecifications : IEntityTypeConfiguration<IdentityResource>
{
    public void Configure(EntityTypeBuilder<IdentityResource> builder)
    {
        builder.Property(identityResource => identityResource.Id)
            .HasColumnName("id");
        builder.Property(identityResource => identityResource.Enabled)
            .HasColumnName("enabled");
        builder.Property(identityResource => identityResource.Name)
            .HasColumnName("name");
        builder.Property(identityResource => identityResource.DisplayName)
            .HasColumnName("display_name");
        builder.Property(identityResource => identityResource.Description)
            .HasColumnName("description");
        builder.Property(identityResource => identityResource.Required)
            .HasColumnName("required");
        builder.Property(identityResource => identityResource.Emphasize)
            .HasColumnName("emphasize");
        builder.Property(identityResource => identityResource.ShowInDiscoveryDocument)
            .HasColumnName("show_in_discovery_document");
        builder.Property(identityResource => identityResource.Created)
            .HasColumnName("created");
        builder.Property(identityResource => identityResource.Updated)
            .HasColumnName("updated");
        builder.Property(identityResource => identityResource.NonEditable)
            .HasColumnName("non_editable");
    }
}