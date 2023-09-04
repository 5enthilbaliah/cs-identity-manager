using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amrita.IdentityManager.Host.Pages.Redirect;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
public class RedirectPageModel : PageModel
{
    public string RedirectUri { get; set; }

    public IActionResult OnGet(string redirectUri)
    {
        if (!Url.IsLocalUrl(redirectUri))
        {
            return RedirectToPage("/Home/Error/Index");
        }

        RedirectUri = redirectUri;
        return Page();
    }
}