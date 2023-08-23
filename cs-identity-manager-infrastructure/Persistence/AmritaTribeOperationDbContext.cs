namespace Amrita.IdentityManager.Infrastructure.Persistence;

using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;

using Specifications.Grant;

public class AmritaTribeOperationDbContext : PersistedGrantDbContext<AmritaTribeOperationDbContext>
{
    public AmritaTribeOperationDbContext(DbContextOptions<AmritaTribeOperationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new PersistedGrantSpecifications()
            .Configure(modelBuilder.Entity<PersistedGrant>());
        new DeviceFlowCodesSpecifications()
            .Configure(modelBuilder.Entity<DeviceFlowCodes>());
        new KeySpecifications()
            .Configure(modelBuilder.Entity<Key>());
        new ServerSideSessionSpecifications()
            .Configure(modelBuilder.Entity<ServerSideSession>());
    }
}