namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiScopePropertySpecifications : IEntityTypeConfiguration<ApiScopeProperty>
{
    public void Configure(EntityTypeBuilder<ApiScopeProperty> builder)
    {
        builder.Property(apiScopeProperty => apiScopeProperty.Id)
            .HasColumnName("id");
        builder.Property(apiScopeProperty => apiScopeProperty.ScopeId)
            .HasColumnName("scope_id");
        builder.Property(apiScopeProperty => apiScopeProperty.Key)
            .HasColumnName("key");
        builder.Property(apiScopeProperty => apiScopeProperty.Value)
            .HasColumnName("value");
    }
}