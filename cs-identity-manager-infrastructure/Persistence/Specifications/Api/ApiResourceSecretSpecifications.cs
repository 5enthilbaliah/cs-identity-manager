namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiResourceSecretSpecifications : IEntityTypeConfiguration<ApiResourceSecret>
{
    public void Configure(EntityTypeBuilder<ApiResourceSecret> builder)
    {
        builder.Property(apiResource => apiResource.Id)
            .HasColumnName("id");
        builder.Property(apiResource => apiResource.ApiResourceId)
            .HasColumnName("api_resource_id");
        builder.Property(apiResource => apiResource.Description)
            .HasColumnName("description");
        builder.Property(apiResource => apiResource.Value)
            .HasColumnName("value");
        builder.Property(apiResource => apiResource.Expiration)
            .HasColumnName("expiration");
        builder.Property(apiResource => apiResource.Type)
            .HasColumnName("type");
        builder.Property(apiResource => apiResource.Created)
            .HasColumnName("created");
    }
}