namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientSecretSpecifications : IEntityTypeConfiguration<ClientSecret>
{
    public void Configure(EntityTypeBuilder<ClientSecret> builder)
    {
        builder.Property(clientSecret => clientSecret.Id)
            .HasColumnName("id");
        builder.Property(clientSecret => clientSecret.Description)
            .HasColumnName("description");
        builder.Property(clientSecret => clientSecret.Value)
            .HasColumnName("value");
        builder.Property(clientSecret => clientSecret.Expiration)
            .HasColumnName("expiration");
        builder.Property(clientSecret => clientSecret.Type)
            .HasColumnName("type");
        builder.Property(clientSecret => clientSecret.Created)
            .HasColumnName("created");
        builder.Property(clientSecret => clientSecret.ClientId)
            .HasColumnName("client_id");
    }
}