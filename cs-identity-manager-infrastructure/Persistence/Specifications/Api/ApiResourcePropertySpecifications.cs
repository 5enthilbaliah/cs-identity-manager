namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiResourcePropertySpecifications : IEntityTypeConfiguration<ApiResourceProperty>
{
    public void Configure(EntityTypeBuilder<ApiResourceProperty> builder)
    {
        builder.Property(apiResource => apiResource.Id)
            .HasColumnName("id");
        builder.Property(apiResource => apiResource.ApiResourceId)
            .HasColumnName("api_resource_id");
        builder.Property(apiResource => apiResource.Key)
            .HasColumnName("key");
        builder.Property(apiResource => apiResource.Value)
            .HasColumnName("value");
    }
}