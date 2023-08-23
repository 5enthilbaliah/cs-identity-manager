namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiResourceSpecifications : IEntityTypeConfiguration<ApiResource>
{
    public void Configure(EntityTypeBuilder<ApiResource> builder)
    {
        builder.Property(apiResource => apiResource.Id)
            .HasColumnName("id");
        builder.Property(apiResource => apiResource.Enabled)
            .HasColumnName("enabled");
        builder.Property(apiResource => apiResource.Name)
            .HasColumnName("name");
        builder.Property(apiResource => apiResource.DisplayName)
            .HasColumnName("display_name");
        builder.Property(apiResource => apiResource.Description)
            .HasColumnName("description");
        builder.Property(apiResource => apiResource.AllowedAccessTokenSigningAlgorithms)
            .HasColumnName("allowed_access_token_signing_algorithms");
        builder.Property(apiResource => apiResource.ShowInDiscoveryDocument)
            .HasColumnName("show_in_discovery_document");
        builder.Property(apiResource => apiResource.RequireResourceIndicator)
            .HasColumnName("require_resource_indicator");
        builder.Property(apiResource => apiResource.Created)
            .HasColumnName("created");
        builder.Property(apiResource => apiResource.Updated)
            .HasColumnName("updated");
        builder.Property(apiResource => apiResource.LastAccessed)
            .HasColumnName("last_accessed");
        builder.Property(apiResource => apiResource.LastAccessed)
            .HasColumnName("last_accessed");
        builder.Property(apiResource => apiResource.NonEditable)
            .HasColumnName("non_editable");
    }
}