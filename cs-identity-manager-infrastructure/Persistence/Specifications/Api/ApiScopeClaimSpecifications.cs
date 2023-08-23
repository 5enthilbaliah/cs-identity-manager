namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Api;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApiScopeClaimSpecifications : IEntityTypeConfiguration<ApiScopeClaim>
{
    public void Configure(EntityTypeBuilder<ApiScopeClaim> builder)
    {
        builder.Property(apiScopeClaim => apiScopeClaim.Id)
            .HasColumnName("id");
        builder.Property(apiScopeClaim => apiScopeClaim.ScopeId)
            .HasColumnName("scope_id");
        builder.Property(apiScopeClaim => apiScopeClaim.Type)
            .HasColumnName("type");
    }
}