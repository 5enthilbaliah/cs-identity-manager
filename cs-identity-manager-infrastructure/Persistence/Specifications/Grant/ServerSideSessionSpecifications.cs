namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Grant;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ServerSideSessionSpecifications : IEntityTypeConfiguration<ServerSideSession>
{
    public void Configure(EntityTypeBuilder<ServerSideSession> builder)
    {
        builder.Property(server => server.Id)
            .HasColumnName("id");
        builder.Property(server => server.Key)
            .HasColumnName("key");
        builder.Property(server => server.Scheme)
            .HasColumnName("scheme");
        builder.Property(server => server.SubjectId)
            .HasColumnName("subject_id");
        builder.Property(server => server.SessionId)
            .HasColumnName("session_id");
        builder.Property(server => server.DisplayName)
            .HasColumnName("display_name");
        builder.Property(server => server.Created)
            .HasColumnName("created");
        builder.Property(server => server.Renewed)
            .HasColumnName("renewed");
        builder.Property(server => server.Expires)
            .HasColumnName("expires");
        builder.Property(server => server.Data)
            .HasColumnName("data");
    }
}