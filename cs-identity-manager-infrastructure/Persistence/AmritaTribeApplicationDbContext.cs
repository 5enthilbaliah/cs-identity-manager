namespace Amrita.IdentityManager.Infrastructure.Persistence;

using Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Specifications.AspNet;

public class AmritaTribeApplicationDbContext : IdentityDbContext<AmritaUser>
{
    public AmritaTribeApplicationDbContext(DbContextOptions<AmritaTribeApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new IdentityRoleSpecifications()
            .Configure(modelBuilder.Entity<IdentityRole>());
        new AmritaUserSpecifications()
            .Configure(modelBuilder.Entity<AmritaUser>());
        new IdentityUserRoleSpecifications()
            .Configure(modelBuilder.Entity<IdentityUserRole<string>>());
        new IdentityUserClaimSpecifications()
            .Configure(modelBuilder.Entity<IdentityUserClaim<string>>());
        new IdentityRoleClaimSpecifications()
            .Configure(modelBuilder.Entity<IdentityRoleClaim<string>>());
        new IdentityUserLoginSpecifications()
            .Configure(modelBuilder.Entity<IdentityUserLogin<string>>());
        new IdentityUserTokenSpecifications()
            .Configure(modelBuilder.Entity<IdentityUserToken<string>>());
    }
}