namespace Amrita.IdentityManager.Presentation.Pages.Account.Login;

using Amrita.IdentityManager.Application.UseCases.Account;

using Application.UseCases.Account.Models;

using Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using UseCaseExecutR.Interfaces;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    private readonly IExecutor _executor;
    private ILogger<LoginPageModel> _logger;
    
    public LoginPageModel(IExecutor executor, ILogger<LoginPageModel> logger)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public LoginViewModel View { get; set; }
    [BindProperty] public SignInModel SignInInfo { get; set; }

    [BindProperty] public SignUpModel SignUpInfo { get; set; }

    [BindProperty] public bool IsSignInSelected { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        IsSignInSelected = true;
        var bindUseCase = new BindLoginUseCase(returnUrl);
        await _executor.ExecuteAsync(bindUseCase);
        var (signIn, view) = bindUseCase.Vm;
        
        SignInInfo = signIn;
        SignUpInfo = new SignUpModel { ReturnUrl = returnUrl };
        View = view;

        if (View.IsExternalLoginOnly)
        {
            // we only have one option for logging in and it's an external provider
            return RedirectToPage("/ExternalLogin/Challenge", new { scheme = View.ExternalLoginScheme, returnUrl });
        }

        _logger.LogInformation("Testing the log {Test}", "Test");
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await Task.CompletedTask;
        return Page();
    }

    public async Task<IActionResult> OnPostSignIn()
    {
        ModelState.RemoveMany("EmailId", "FullName", "Password");
        if (ModelState.IsValid)
        {
            var loginUseCase = new LoginUseCase(SignInInfo, Url.IsLocalUrl);
            await _executor.ExecuteAsync(loginUseCase);
            
            if (loginUseCase.Vm.LoginResponseType == LoginResponseType.Redirect)
            {
                return Redirect(loginUseCase.Vm.RedirectUrl!);
            }

            if (loginUseCase.Vm.LoginResponseType == LoginResponseType.LoadingPage)
            {
                return this.LoadingPage(loginUseCase.Vm.RedirectUrl!);
            }

            ModelState.AddModelError("SignInInfo.Password", LoginOptions.InvalidCredentialsErrorMessage);
        }

        // something went wrong, show form with error
#pragma warning disable CS8604 // Possible null reference argument.
        var bindUseCase = new BindLoginUseCase(SignInInfo.ReturnUrl);
        await _executor.ExecuteAsync(bindUseCase);
        var (signIn, view) = bindUseCase.Vm;
#pragma warning restore CS8604 // Possible null reference argument.
        SignInInfo = signIn;
        View = view;

        IsSignInSelected = true;
        return Page();
    }

    public async Task<IActionResult> OnPostSignUp()
    {
        ModelState.RemoveMany("EmailId", "Password");
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var registrationUseCase = new RegistrationUseCase(SignUpInfo, Url.IsLocalUrl);
        await _executor.ExecuteAsync(registrationUseCase);
        if (registrationUseCase.Vm.LoginResponseType == LoginResponseType.Redirect)
        {
            return Redirect(registrationUseCase.Vm.RedirectUrl!);
        }

        if (registrationUseCase.Vm.LoginResponseType == LoginResponseType.Failed)
        {
            var firstError = registrationUseCase.Vm.Errors.First();
            ModelState.AddModelError($"SignUpInfo.{firstError.Key}", firstError.Value);
        }

        return Page();
    }
}