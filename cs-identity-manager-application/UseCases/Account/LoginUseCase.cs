namespace Amrita.IdentityManager.Application.UseCases.Account;

using Domain;

using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

using Models;

using UseCaseExecutR.Interfaces;

public record LoginUseCase(SignInModel SignIn, Func<string, bool> LocalUrlCheck) :
    IUseCase<LoginResponseModel>
{
    public LoginResponseModel Vm { get; set; } = null!;
}

public record BindLoginUseCase(string ReturnUrl) : IUseCase<(SignInModel, LoginViewModel)>
{
    public (SignInModel, LoginViewModel) Vm { get; set; }
}

public class LoginUseCaseRunner : IUseCaseRunner<LoginUseCase, LoginResponseModel>,
    IUseCaseRunner<BindLoginUseCase, (SignInModel, LoginViewModel)>
{
    private readonly IEventService _events;
    private readonly IIdentityProviderStore _identityProviderStore;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly SignInManager<AmritaUser> _signInManager;

    public LoginUseCaseRunner(IEventService events, IIdentityProviderStore identityProviderStore,
        IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider,
        SignInManager<AmritaUser> signInManager)
    {
        _events = events ?? throw new ArgumentNullException(nameof(events));
        _identityProviderStore =
            identityProviderStore ?? throw new ArgumentNullException(nameof(identityProviderStore));
        _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
        _schemeProvider = schemeProvider ?? throw new ArgumentNullException(nameof(schemeProvider));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<(SignInModel, LoginViewModel)> Run(BindLoginUseCase useCase, CancellationToken cancellationToken)
    {
        var signIn = new SignInModel { ReturnUrl = useCase.ReturnUrl };
        var context = await _interaction.GetAuthorizationContextAsync(useCase.ReturnUrl);
        if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
        {
            var local = context.IdP == IdentityServerConstants.LocalIdentityProvider;

            // this is meant to short circuit the UI and only trigger the one external IdP
            var view = new LoginViewModel { EnableLocalLogin = local };
            signIn.EmailId = context.LoginHint ?? string.Empty;

            if (!local)
            {
                view.ExternalProviders = new[]
                {
                    new LoginViewModel.ExternalProvider { AuthenticationScheme = context.IdP ?? "Bearer" }
                };
            }

            return (signIn, view);
        }

        var schemes = await _schemeProvider.GetAllSchemesAsync();
        var providers = schemes
            .Where(x => x.DisplayName != null)
            .Select(x => new LoginViewModel.ExternalProvider
            {
                DisplayName = x.DisplayName ?? x.Name, AuthenticationScheme = x.Name
            }).ToList();

        var dynamicSchemes = (await _identityProviderStore.GetAllSchemeNamesAsync())
            .Where(x => x.Enabled)
            .Select(x => new LoginViewModel.ExternalProvider
            {
                AuthenticationScheme = x.Scheme, DisplayName = x.DisplayName ?? "default"
            });
        providers.AddRange(dynamicSchemes);

        var allowLocal = true;
        var client = context?.Client;
        if (client != null)
        {
            allowLocal = client.EnableLocalLogin;
            if (client.IdentityProviderRestrictions.Any())
            {
                providers = providers.Where(provider =>
                    client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
            }
        }

        return (signIn,
            new LoginViewModel
            {
                AllowRememberLogin = LoginOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && LoginOptions.AllowLocalLogin,
                ExternalProviders = providers.ToArray()
            });
    }

    public async Task<LoginResponseModel> Run(LoginUseCase useCase, CancellationToken cancellationToken)
    {
        var context = await _interaction.GetAuthorizationContextAsync(useCase.SignIn.ReturnUrl);
        var signInResult = await _signInManager.PasswordSignInAsync(useCase.SignIn.EmailId, useCase.SignIn.Password,
            useCase.SignIn.RememberLogin, false);

        if (signInResult.Succeeded)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(useCase.SignIn.EmailId);
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName,
                clientId: context?.Client.ClientId));

            // only set explicit expiration here if user chooses "remember me". 
            // otherwise we rely upon expiration configured in cookie middleware.
            AuthenticationProperties props = null;
            if (LoginOptions.AllowRememberLogin && useCase.SignIn.RememberLogin)
            {
                props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(LoginOptions.RememberMeLoginDuration)
                };
            }

            // issue authentication cookie with subject ID and username

            // var issuer = new IdentityServerUser(user.Id) { DisplayName = user.UserName };
            // await HttpContext.SignInAsync(issuer, props);

            if (context != null)
            {
                var isNativeClient = !context.RedirectUri.StartsWith("https", StringComparison.Ordinal)
                                     && !context.RedirectUri.StartsWith("http", StringComparison.Ordinal);
                if (isNativeClient)
                {
                    // The client is native, so this change in how to
                    // return the response is for better UX for the end user.
                    return new LoginResponseModel
                    {
                        LoginResponseType = LoginResponseType.LoadingPage, RedirectUrl = useCase.SignIn.ReturnUrl
                    };
                }

                // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                return new LoginResponseModel
                {
                    LoginResponseType = LoginResponseType.Redirect, RedirectUrl = useCase.SignIn.ReturnUrl
                };
            }

            // request for a local page
            if (useCase.LocalUrlCheck(useCase.SignIn.ReturnUrl))
            {
                return new LoginResponseModel
                {
                    LoginResponseType = LoginResponseType.Redirect, RedirectUrl = useCase.SignIn.ReturnUrl
                };
            }

            if (string.IsNullOrEmpty(useCase.SignIn.ReturnUrl))
            {
                return new LoginResponseModel { LoginResponseType = LoginResponseType.Redirect, RedirectUrl = "~/" };
            }

            // user might have clicked on a malicious link - should be logged
            throw new Exception("invalid return URL");
        }

        await _events.RaiseAsync(new UserLoginFailureEvent(useCase.SignIn.EmailId, "invalid credentials",
            clientId: context?.Client.ClientId));

        return new LoginResponseModel { LoginResponseType = LoginResponseType.Failed };
    }
}