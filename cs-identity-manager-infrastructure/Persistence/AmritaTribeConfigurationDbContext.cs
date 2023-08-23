namespace Amrita.IdentityManager.Infrastructure.Persistence;

using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;

using Specifications.Api;
using Specifications.Client;
using Specifications.Identity;

public class AmritaTribeConfigurationDbContext : ConfigurationDbContext<AmritaTribeConfigurationDbContext>
{
    public AmritaTribeConfigurationDbContext(DbContextOptions<AmritaTribeConfigurationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ApiResourceClaimSpecifications()
            .Configure(modelBuilder.Entity<ApiResourceClaim>());
        new ApiResourcePropertySpecifications()
            .Configure(modelBuilder.Entity<ApiResourceProperty>());
        new ApiResourceScopeSpecifications()
            .Configure(modelBuilder.Entity<ApiResourceScope>());
        new ApiResourceSecretSpecifications()
            .Configure(modelBuilder.Entity<ApiResourceSecret>());
        new ApiResourceSpecifications()
            .Configure(modelBuilder.Entity<ApiResource>());
        new ApiScopeClaimSpecifications()
            .Configure(modelBuilder.Entity<ApiScopeClaim>());
        new ApiScopePropertySpecifications()
            .Configure(modelBuilder.Entity<ApiScopeProperty>());
        new ApiScopeSpecifications()
            .Configure(modelBuilder.Entity<ApiScope>());

        new ClientClaimSpecifications()
            .Configure(modelBuilder.Entity<ClientClaim>());
        new ClientCorsOriginSpecifications()
            .Configure(modelBuilder.Entity<ClientCorsOrigin>());
        new ClientGrantTypeSpecifications()
            .Configure(modelBuilder.Entity<ClientGrantType>());
        new ClientIdPRestrictionSpecifications()
            .Configure(modelBuilder.Entity<ClientIdPRestriction>());
        new ClientPostLogoutRedirectUriSpecifications()
            .Configure(modelBuilder.Entity<ClientPostLogoutRedirectUri>());
        new ClientPropertySpecifications()
            .Configure(modelBuilder.Entity<ClientProperty>());
        new ClientRedirectUriSpecifications()
            .Configure(modelBuilder.Entity<ClientRedirectUri>());
        new ClientScopeSpecifications()
            .Configure(modelBuilder.Entity<ClientScope>());
        new ClientSecretSpecifications()
            .Configure(modelBuilder.Entity<ClientSecret>());
        new ClientSpecifications()
            .Configure(modelBuilder.Entity<Client>());

        new IdentityProviderSpecifications()
            .Configure(modelBuilder.Entity<IdentityProvider>());
        new IdentityResourceClaimSpecifications()
            .Configure(modelBuilder.Entity<IdentityResourceClaim>());
        new IdentityResourcePropertySpecifications()
            .Configure(modelBuilder.Entity<IdentityResourceProperty>());
        new IdentityResourceSpecifications()
            .Configure(modelBuilder.Entity<IdentityResource>());
    }
}