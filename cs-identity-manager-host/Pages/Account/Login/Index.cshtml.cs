namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Application.Login;
using Application.Login.Interfaces;
using Application.Login.Models;

using Domain;

using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    private readonly IEventService _events;
    private readonly IIdentityProviderStore _identityProviderStore;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly ILoginService _loginService;
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly SignInManager<AmritaUser> _signInManager;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LoginPageModel(
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        IIdentityServerInteractionService interaction,
        IAuthenticationSchemeProvider schemeProvider,
        IIdentityProviderStore identityProviderStore,
        IEventService events,
        SignInManager<AmritaUser> signInManager, ILoginService loginService)
    {
        _interaction = interaction;
        _schemeProvider = schemeProvider;
        _identityProviderStore = identityProviderStore;
        _events = events;
        _signInManager = signInManager;
        _loginService = loginService;
    }

    public LoginViewModel View { get; set; }
    [BindProperty] public SignInModel SignInInfo { get; set; }

    [BindProperty] public SignUpModel SignUpInfo { get; set; }

    [BindProperty] public bool IsSignInSelected { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        IsSignInSelected = true;
        (var signIn, var view) = await _loginService.BindModelsAsync(returnUrl);
        SignInInfo = signIn;
        

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
            var loginResponse = await _loginService.SignInAsync(SignInInfo, returnUrl => Url.IsLocalUrl(returnUrl));

            if (loginResponse.LoginResponseType == LoginResponseType.Redirect)
            {
                return Redirect(loginResponse.RedirectUrl!);
            }

            if (loginResponse.LoginResponseType == LoginResponseType.LoadingPage)
            {
                return this.LoadingPage(loginResponse.RedirectUrl!);
            }

            ModelState.AddModelError("SignInInfo.Password", LoginOptions.InvalidCredentialsErrorMessage);
        }

        // something went wrong, show form with error
        await _loginService.BindModelsAsync(SignInInfo.ReturnUrl);
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
}