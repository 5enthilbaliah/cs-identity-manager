namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientPropertySpecifications : IEntityTypeConfiguration<ClientProperty>
{
    public void Configure(EntityTypeBuilder<ClientProperty> builder)
    {
        builder.Property(clientProperty => clientProperty.Id)
            .HasColumnName("id");
        builder.Property(clientProperty => clientProperty.Key)
            .HasColumnName("key");
        builder.Property(clientProperty => clientProperty.Value)
            .HasColumnName("value");
        builder.Property(clientProperty => clientProperty.ClientId)
            .HasColumnName("client_id");
    }
}