namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiScopeSpecifications : IEntityTypeConfiguration<ApiScope>
{
    public void Configure(EntityTypeBuilder<ApiScope> builder)
    {
        builder.Property(apiScope => apiScope.Id)
            .HasColumnName("id");
        builder.Property(apiScope => apiScope.Enabled)
            .HasColumnName("enabled");
        builder.Property(apiScope => apiScope.Name)
            .HasColumnName("name");
        builder.Property(apiScope => apiScope.DisplayName)
            .HasColumnName("display_name");
        builder.Property(apiScope => apiScope.Description)
            .HasColumnName("description");
        builder.Property(apiScope => apiScope.Required)
            .HasColumnName("required");
        builder.Property(apiScope => apiScope.Emphasize)
            .HasColumnName("emphasize");
        builder.Property(apiScope => apiScope.ShowInDiscoveryDocument)
            .HasColumnName("show_in_discovery_document");
        builder.Property(apiScope => apiScope.Created)
            .HasColumnName("created");
        builder.Property(apiScope => apiScope.Updated)
            .HasColumnName("updated");
        builder.Property(apiScope => apiScope.LastAccessed)
            .HasColumnName("last_accessed");
        builder.Property(apiScope => apiScope.NonEditable)
            .HasColumnName("non_editable");
    }
}