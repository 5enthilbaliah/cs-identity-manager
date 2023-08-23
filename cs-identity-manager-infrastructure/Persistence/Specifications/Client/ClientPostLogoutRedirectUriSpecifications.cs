namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientPostLogoutRedirectUriSpecifications : IEntityTypeConfiguration<ClientPostLogoutRedirectUri>
{
    public void Configure(EntityTypeBuilder<ClientPostLogoutRedirectUri> builder)
    {
        builder.Property(clientPostRedirectUri => clientPostRedirectUri.Id)
            .HasColumnName("id");
        builder.Property(clientPostRedirectUri => clientPostRedirectUri.PostLogoutRedirectUri)
            .HasColumnName("post_logout_redirect_uri");
        builder.Property(clientPostRedirectUri => clientPostRedirectUri.ClientId)
            .HasColumnName("client_id");
    }
}