namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientIdPRestrictionSpecifications : IEntityTypeConfiguration<ClientIdPRestriction>
{
    public void Configure(EntityTypeBuilder<ClientIdPRestriction> builder)
    {
        builder.Property(clientGIdPRestriction => clientGIdPRestriction.Id)
            .HasColumnName("id");
        builder.Property(clientGIdPRestriction => clientGIdPRestriction.Provider)
            .HasColumnName("provider");
        builder.Property(clientGIdPRestriction => clientGIdPRestriction.ClientId)
            .HasColumnName("client_id");
    }
}