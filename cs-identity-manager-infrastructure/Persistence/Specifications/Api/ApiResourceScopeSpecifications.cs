namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiResourceScopeSpecifications : IEntityTypeConfiguration<ApiResourceScope>
{
    public void Configure(EntityTypeBuilder<ApiResourceScope> builder)
    {
        builder.Property(apiResource => apiResource.Id)
            .HasColumnName("id");
        builder.Property(apiResource => apiResource.Scope)
            .HasColumnName("scope");
        builder.Property(apiResource => apiResource.ApiResourceId)
            .HasColumnName("api_resource_id");
    }
}