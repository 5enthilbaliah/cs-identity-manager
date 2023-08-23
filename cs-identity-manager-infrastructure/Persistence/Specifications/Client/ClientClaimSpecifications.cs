namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientClaimSpecifications : IEntityTypeConfiguration<ClientClaim>
{
    public void Configure(EntityTypeBuilder<ClientClaim> builder)
    {
        builder.Property(clientClaim => clientClaim.Id)
            .HasColumnName("id");
        builder.Property(clientClaim => clientClaim.Type)
            .HasColumnName("type");
        builder.Property(clientClaim => clientClaim.ClientId)
            .HasColumnName("client_id");
        builder.Property(clientClaim => clientClaim.Value)
            .HasColumnName("value");
    }
}