namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Application.Login;
using Application.Login.Interfaces;
using Application.Login.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    private readonly ILoginService _loginService;
    private readonly IRegistrationService _registrationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LoginPageModel(ILoginService loginService, IRegistrationService registrationService)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
    }

    public LoginViewModel View { get; set; }
    [BindProperty] public SignInModel SignInInfo { get; set; }

    [BindProperty] public SignUpModel SignUpInfo { get; set; }

    [BindProperty] public bool IsSignInSelected { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        IsSignInSelected = true;
        var (signIn, view) = await _loginService.BindModelsAsync(returnUrl);
        SignInInfo = signIn;
        SignUpInfo = new SignUpModel { ReturnUrl = returnUrl };
        View = view;

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
#pragma warning disable CS8604 // Possible null reference argument.
        var (signIn, view) = await _loginService.BindModelsAsync(SignInInfo.ReturnUrl);
#pragma warning restore CS8604 // Possible null reference argument.
        SignInInfo = signIn;
        View = view;

        IsSignInSelected = true;
        return Page();
    }

    public async Task<IActionResult> OnPostSignUp()
    {
        ModelState.RemoveMany("UserName", "Password");
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var registrationResponse = await _registrationService.RegisterCustomerAsync(SignUpInfo,
            returnUrl => Url.IsLocalUrl(returnUrl));
            
        if (registrationResponse.LoginResponseType == LoginResponseType.Redirect)
        {
            return Redirect(registrationResponse.RedirectUrl!);
        }

        if (registrationResponse.LoginResponseType == LoginResponseType.Failed)
        {
            var firstError = registrationResponse.Errors.First();
            ModelState.AddModelError($"SignUpInfo.{firstError.Key}", firstError.Value);
        }

        return Page();
    }
}