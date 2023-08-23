namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Grant;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class KeySpecifications : IEntityTypeConfiguration<Key>
{
    public void Configure(EntityTypeBuilder<Key> builder)
    {
        builder.Property(key => key.Id)
            .HasColumnName("id");
        builder.Property(key => key.Version)
            .HasColumnName("version");
        builder.Property(key => key.Created)
            .HasColumnName("created");
        builder.Property(key => key.Use)
            .HasColumnName("use");
        builder.Property(key => key.Algorithm)
            .HasColumnName("algorithm");
        builder.Property(key => key.IsX509Certificate)
            .HasColumnName("is_x509_certificate");
        builder.Property(key => key.DataProtected)
            .HasColumnName("data_protected");
        builder.Property(key => key.Data)
            .HasColumnName("data");
    }
}