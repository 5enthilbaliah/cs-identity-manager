namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientRedirectUriSpecifications : IEntityTypeConfiguration<ClientRedirectUri>
{
    public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
    {
        builder.Property(clientRedirectUri => clientRedirectUri.Id)
            .HasColumnName("id");
        builder.Property(clientRedirectUri => clientRedirectUri.ClientId)
            .HasColumnName("client_id");
        builder.Property(clientRedirectUri => clientRedirectUri.RedirectUri)
            .HasColumnName("redirect_uri");
    }
}