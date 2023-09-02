namespace Amrita.IdentityManager.Host;

using Duende.IdentityServer;
using Duende.IdentityServer.Models;

using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new[]
        {
            new IdentityResources.OpenId(), new IdentityResources.Profile(), new IdentityResources.Email(),
            new IdentityResource { Name = "profile-picture", UserClaims = new List<string> { "profile-picture" } },
            new IdentityResource { Name = "role", UserClaims = new List<string> { "role" } }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] { new ApiScope("test-api.read"), new ApiScope("test-api.write") };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("test-api")
        {
            Scopes = new List<string> { "test-api.read", "test-api.write" },
            ApiSecrets = new List<Secret> { new("Scope$ecret".Sha256()) },
            UserClaims = new List<string> { "role" }
        }
    };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "test-m2m",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },
                AllowedScopes = { "test-api.read", "test-api.write" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "test-interactive",
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5444/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    "test-api.read",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId
                },
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false
            }
        };

    public static string SuperAdminRole => "super-admin";
    public static string CustomerRole => "customer";
}