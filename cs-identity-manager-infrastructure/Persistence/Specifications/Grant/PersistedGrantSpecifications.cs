namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Grant;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersistedGrantSpecifications : IEntityTypeConfiguration<PersistedGrant>
{
    public void Configure(EntityTypeBuilder<PersistedGrant> builder)
    {
        builder.Property(grant => grant.Id)
            .HasColumnName("id");
        builder.Property(grant => grant.Key)
            .HasColumnName("key");
        builder.Property(grant => grant.Type)
            .HasColumnName("type");
        builder.Property(grant => grant.SubjectId)
            .HasColumnName("subject_id");
        builder.Property(grant => grant.SessionId)
            .HasColumnName("session_id");
        builder.Property(grant => grant.ClientId)
            .HasColumnName("client_id");
        builder.Property(grant => grant.Description)
            .HasColumnName("description");
        builder.Property(grant => grant.CreationTime)
            .HasColumnName("creation_time");
        builder.Property(grant => grant.Expiration)
            .HasColumnName("expiration");
        builder.Property(grant => grant.ConsumedTime)
            .HasColumnName("consumed_time");
        builder.Property(grant => grant.Data)
            .HasColumnName("data");
    }
}