namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    [BindProperty] public SignInModel? SignInInfo { get; set; }

    [BindProperty] public SignUpModel? SignUpInfo { get; set; }

    public void OnGet()
    {
    }
}