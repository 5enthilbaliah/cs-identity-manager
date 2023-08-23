namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Grant;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DeviceFlowCodesSpecifications : IEntityTypeConfiguration<DeviceFlowCodes>
{
    public void Configure(EntityTypeBuilder<DeviceFlowCodes> builder)
    {
        builder.Property(device => device.DeviceCode)
            .HasColumnName("code");
        builder.Property(device => device.UserCode)
            .HasColumnName("user_code");
        builder.Property(device => device.SubjectId)
            .HasColumnName("subject_id");
        builder.Property(device => device.SessionId)
            .HasColumnName("session_id");
        builder.Property(device => device.ClientId)
            .HasColumnName("client_id");
        builder.Property(device => device.Description)
            .HasColumnName("description");
        builder.Property(device => device.CreationTime)
            .HasColumnName("creation_time");
        builder.Property(device => device.Expiration)
            .HasColumnName("expiration");
        builder.Property(device => device.Data)
            .HasColumnName("data");
    }
}