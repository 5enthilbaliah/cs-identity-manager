namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Domain;

using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    private readonly IEventService _events;
    private readonly IIdentityProviderStore _identityProviderStore;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly SignInManager<AmritaUser> _signInManager;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LoginPageModel(
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        IIdentityServerInteractionService interaction,
        IAuthenticationSchemeProvider schemeProvider,
        IIdentityProviderStore identityProviderStore,
        IEventService events,
        SignInManager<AmritaUser> signInManager)
    {
        _interaction = interaction;
        _schemeProvider = schemeProvider;
        _identityProviderStore = identityProviderStore;
        _events = events;
        _signInManager = signInManager;
    }

    public LoginViewModel View { get; set; }
    [BindProperty] public SignInModel SignInInfo { get; set; }

    [BindProperty] public SignUpModel SignUpInfo { get; set; }

    [BindProperty] public bool IsSignInSelected { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        IsSignInSelected = true;
        await BuildModelAsync(returnUrl);

        if (View.IsExternalLoginOnly)
        {
            // we only have one option for logging in and it's an external provider
            return RedirectToPage("/ExternalLogin/Challenge", new { scheme = View.ExternalLoginScheme, returnUrl });
        }

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await Task.CompletedTask;
        return Page();
    }

    public async Task<IActionResult> OnPostSignIn()
    {
        ModelState.RemoveMany("Email", "FullName", "UserName", "Password");
        if (ModelState.IsValid)
        {
            // check if we are in the context of an authorization request
            var context = await _interaction.GetAuthorizationContextAsync(SignInInfo.ReturnUrl);
            var user = await _signInManager.UserManager.FindByNameAsync(SignInInfo.UserName);
            if (user is not null && (await _signInManager.CheckPasswordSignInAsync(user, SignInInfo.Password, false))
                == SignInResult.Success)
            {
                ;
            }
        }

        IsSignInSelected = true;
        return Page();
    }

    public async Task<IActionResult> OnPostSignUp()
    {
        ModelState.RemoveMany("UserName", "Password");
        if (ModelState.IsValid)
        {
            await Task.CompletedTask;
        }

        return Page();
    }

    private async Task BuildModelAsync(string returnUrl)
    {
        SignInInfo = new SignInModel { ReturnUrl = returnUrl };
        SignUpInfo = new SignUpModel();

        var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
        if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
        {
            var local = context.IdP == IdentityServerConstants.LocalIdentityProvider;

            // this is meant to short circuit the UI and only trigger the one external IdP
            View = new LoginViewModel { EnableLocalLogin = local };

            SignInInfo.UserName = context.LoginHint ?? string.Empty;

            if (!local)
            {
                View.ExternalProviders = new[]
                {
                    new LoginViewModel.ExternalProvider { AuthenticationScheme = context.IdP ?? "Bearer"}
                };
            }

            return;
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

        View = new LoginViewModel
        {
            AllowRememberLogin = LoginOptions.AllowRememberLogin,
            EnableLocalLogin = allowLocal && LoginOptions.AllowLocalLogin,
            ExternalProviders = providers.ToArray()
        };
    }
}