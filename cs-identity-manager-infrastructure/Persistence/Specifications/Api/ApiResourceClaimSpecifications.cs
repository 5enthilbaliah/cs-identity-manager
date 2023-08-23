namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiResourceClaimSpecifications : IEntityTypeConfiguration<ApiResourceClaim>
{
    public void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
    {
        builder.Property(apiResource => apiResource.Id)
            .HasColumnName("id");
        builder.Property(apiResource => apiResource.ApiResourceId)
            .HasColumnName("api_resource_id");
        builder.Property(apiResource => apiResource.Type)
            .HasColumnName("type");
    }
}