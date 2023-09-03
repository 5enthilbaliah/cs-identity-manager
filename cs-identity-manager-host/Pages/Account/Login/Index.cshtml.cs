using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using Microsoft.AspNetCore.Authorization;

[SecurityHeaders]
[AllowAnonymous]
public class LoginPageModel : PageModel
{
    public void OnGet()
    {
        
    }
}