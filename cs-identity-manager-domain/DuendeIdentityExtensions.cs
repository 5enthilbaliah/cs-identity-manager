namespace Amrita.IdentityManager.Domain;

using Duende.IdentityServer.EntityFramework.Options;

public static class DuendeIdentityExtensions
{
    public static void Setup(this ConfigurationStoreOptions options)
    {
        options.ApiResource = new TableConfiguration("resource", "api");
        options.ApiScope = new TableConfiguration("scope", "api");
        options.ApiResourceClaim = new TableConfiguration("resource_claim", "api");
        options.ApiResourceProperty = new TableConfiguration("resource_property", "api");
        options.ApiResourceScope = new TableConfiguration("resource_scope", "api");
        options.ApiResourceSecret = new TableConfiguration("resource_secret", "api");
        options.ApiScopeClaim = new TableConfiguration("scope_claim", "api");
        options.ApiScopeProperty = new TableConfiguration("scope_property", "api");
        options.Client = new TableConfiguration("info", "client");
        options.ClientClaim = new TableConfiguration("claim", "client");
        options.ClientCorsOrigin = new TableConfiguration("cors_origin", "client");
        options.ClientGrantType = new TableConfiguration("grant_type", "client");
        options.ClientIdPRestriction = new TableConfiguration("id_p_restriction", "client");
        options.ClientPostLogoutRedirectUri = new TableConfiguration("post_logout_redirect_uri", "client");
        options.ClientProperty = new TableConfiguration("property", "client");
        options.ClientRedirectUri = new TableConfiguration("redirect_uri", "client");
        options.ClientScopes = new TableConfiguration("scope", "client");
        options.ClientSecret = new TableConfiguration("secret", "client");
        options.IdentityProvider = new TableConfiguration("provider", "identity");
        options.IdentityResource = new TableConfiguration("resource", "identity");
        options.IdentityResourceClaim = new TableConfiguration("resource_claim", "identity");
        options.IdentityResourceProperty = new TableConfiguration("resource_property", "identity");
    }

    public static void Setup(this OperationalStoreOptions options)
    {
        options.PersistedGrants = new TableConfiguration("persisted_grant", "grant");
        options.DeviceFlowCodes = new TableConfiguration("device_flow_code", "grant");
        options.Keys = new TableConfiguration("key", "grant");
        options.ServerSideSessions = new TableConfiguration("server_side_session", "grant");
    }
}