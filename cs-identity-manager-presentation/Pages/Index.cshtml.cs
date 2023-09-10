namespace Amrita.IdentityManager.Presentation.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}