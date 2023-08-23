namespace Amrita.IdentityManager.Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Specifications.AspNet;

public class AmritaTribeApplicationDbContext : IdentityDbContext
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
        new IdentityUserSpecifications()
            .Configure(modelBuilder.Entity<IdentityUser>());
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