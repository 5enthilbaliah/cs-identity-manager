namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientScopeSpecifications : IEntityTypeConfiguration<ClientScope>
{
    public void Configure(EntityTypeBuilder<ClientScope> builder)
    {
        builder.Property(clientScope => clientScope.Id)
            .HasColumnName("id");
        builder.Property(clientScope => clientScope.ClientId)
            .HasColumnName("client_id");
        builder.Property(clientScope => clientScope.Scope)
            .HasColumnName("scope");
    }
}