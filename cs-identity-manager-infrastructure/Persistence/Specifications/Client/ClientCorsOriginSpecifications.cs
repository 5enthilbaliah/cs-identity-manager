namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientCorsOriginSpecifications : IEntityTypeConfiguration<ClientCorsOrigin>
{
    public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
    {
        builder.Property(clientCorsOrigin => clientCorsOrigin.Id)
            .HasColumnName("id");
        builder.Property(clientCorsOrigin => clientCorsOrigin.Origin)
            .HasColumnName("origin");
        builder.Property(clientCorsOrigin => clientCorsOrigin.ClientId)
            .HasColumnName("client_id");
    }
}