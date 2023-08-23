namespace Amrita.IdentityManager.Infrastructure.Persistence.Specifications.Client;

using Duende.IdentityServer.EntityFramework.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientSpecifications : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(client => client.Id)
            .HasColumnName("id");
        builder.Property(client => client.Enabled)
            .HasColumnName("enabled");
        builder.Property(client => client.ClientId)
            .HasColumnName("client_id");
        builder.Property(client => client.ProtocolType)
            .HasColumnName("protocol_type");
        builder.Property(client => client.RequireClientSecret)
            .HasColumnName("require_client_secret");
        builder.Property(client => client.ClientName)
            .HasColumnName("client_name");
        builder.Property(client => client.Description)
            .HasColumnName("description");
        builder.Property(client => client.ClientUri)
            .HasColumnName("client_uri");
        builder.Property(client => client.LogoUri)
            .HasColumnName("logo_uri");
        builder.Property(client => client.RequireConsent)
            .HasColumnName("require_consent");
        builder.Property(client => client.AllowRememberConsent)
            .HasColumnName("allow_remember_consent");
        builder.Property(client => client.AlwaysIncludeUserClaimsInIdToken)
            .HasColumnName("always_include_user_claims_in_id_token");
        builder.Property(client => client.RequirePkce)
            .HasColumnName("require_pkce");
        builder.Property(client => client.AllowPlainTextPkce)
            .HasColumnName("allow_plain_text_pkce");
        builder.Property(client => client.RequireRequestObject)
            .HasColumnName("require_request_object");
        builder.Property(client => client.AllowAccessTokensViaBrowser)
            .HasColumnName("allow_access_tokens_via_browser");
        builder.Property(client => client.RequireDPoP)
            .HasColumnName("require_d_pop");
        builder.Property(client => client.DPoPValidationMode)
            .HasColumnName("d_pop_validation_mode");
        builder.Property(client => client.DPoPClockSkew)
            .HasColumnName("d_pop_clock_skew");
        builder.Property(client => client.DPoPClockSkew)
            .HasColumnName("d_pop_clock_skew");
        builder.Property(client => client.FrontChannelLogoutUri)
            .HasColumnName("front_channel_logout_uri");
        builder.Property(client => client.FrontChannelLogoutSessionRequired)
            .HasColumnName("front_channel_logout_session_required");
        builder.Property(client => client.BackChannelLogoutUri)
            .HasColumnName("back_channel_logout_uri");
        builder.Property(client => client.BackChannelLogoutSessionRequired)
            .HasColumnName("back_channel_logout_session_required");
        builder.Property(client => client.AllowOfflineAccess)
            .HasColumnName("allow_offline_access");
        builder.Property(client => client.IdentityTokenLifetime)
            .HasColumnName("identity_token_lifetime");
        builder.Property(client => client.AllowedIdentityTokenSigningAlgorithms)
            .HasColumnName("allowed_identity_token_signing_algorithms");
        builder.Property(client => client.AccessTokenLifetime)
            .HasColumnName("access_token_lifetime");
        builder.Property(client => client.AuthorizationCodeLifetime)
            .HasColumnName("authorization_code_lifetime");
        builder.Property(client => client.ConsentLifetime)
            .HasColumnName("consent_lifetime");
        builder.Property(client => client.AbsoluteRefreshTokenLifetime)
            .HasColumnName("absolute_refresh_token_lifetime");
        builder.Property(client => client.SlidingRefreshTokenLifetime)
            .HasColumnName("sliding_refresh_token_lifetime");
        builder.Property(client => client.RefreshTokenUsage)
            .HasColumnName("refresh_token_usage");
        builder.Property(client => client.UpdateAccessTokenClaimsOnRefresh)
            .HasColumnName("update_access_token_claims_on_refresh");
        builder.Property(client => client.RefreshTokenExpiration)
            .HasColumnName("refresh_token_expiration");
        builder.Property(client => client.AccessTokenType)
            .HasColumnName("access_token_type");
        builder.Property(client => client.EnableLocalLogin)
            .HasColumnName("enable_local_login");
        builder.Property(client => client.IncludeJwtId)
            .HasColumnName("include_jwt_id");
        builder.Property(client => client.AlwaysSendClientClaims)
            .HasColumnName("always_send_client_claims");
        builder.Property(client => client.ClientClaimsPrefix)
            .HasColumnName("client_claims_prefix");
        builder.Property(client => client.PairWiseSubjectSalt)
            .HasColumnName("pair_wise_subject_salt");
        builder.Property(client => client.InitiateLoginUri)
            .HasColumnName("initiate_login_uri");
        builder.Property(client => client.UserSsoLifetime)
            .HasColumnName("user_sso_lifetime");
        builder.Property(client => client.UserCodeType)
            .HasColumnName("user_code_type");
        builder.Property(client => client.DeviceCodeLifetime)
            .HasColumnName("device_code_lifetime");
        builder.Property(client => client.CibaLifetime)
            .HasColumnName("ciba_lifetime");
        builder.Property(client => client.PollingInterval)
            .HasColumnName("polling_interval");
        builder.Property(client => client.CoordinateLifetimeWithUserSession)
            .HasColumnName("coordinate_lifetime_with_user_session");
        builder.Property(client => client.Created)
            .HasColumnName("created");
        builder.Property(client => client.Updated)
            .HasColumnName("updated");
        builder.Property(client => client.LastAccessed)
            .HasColumnName("last_accessed");
        builder.Property(client => client.NonEditable)
            .HasColumnName("non_editable");
    }
}