namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Domain;

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
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly SignInManager<AmritaUser> _signInManager;

    public LoginPageModel(
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

    [BindProperty] public SignInModel? SignInInfo { get; set; }

    [BindProperty] public SignUpModel? SignUpInfo { get; set; }

    [BindProperty] public bool IsSignInSelected { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        IsSignInSelected = true;
        await BuildModelAsync(returnUrl);
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
            await Task.CompletedTask;
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
        await Task.CompletedTask;
    }
}