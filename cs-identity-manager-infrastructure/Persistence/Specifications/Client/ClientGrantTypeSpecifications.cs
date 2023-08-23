namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientGrantTypeSpecifications : IEntityTypeConfiguration<ClientGrantType>
{
    public void Configure(EntityTypeBuilder<ClientGrantType> builder)
    {
        builder.Property(clientGrantType => clientGrantType.Id)
            .HasColumnName("id");
        builder.Property(clientGrantType => clientGrantType.GrantType)
            .HasColumnName("grant_type");
        builder.Property(clientGrantType => clientGrantType.ClientId)
            .HasColumnName("client_id");
    }
}