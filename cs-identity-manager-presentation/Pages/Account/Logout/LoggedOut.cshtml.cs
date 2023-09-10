namespace Amrita.IdentityManager.Presentation.Pages.Account.Logout;

using Amrita.IdentityManager.Presentation.Pages;
using Duende.IdentityServer.Services;
using Host.Pages.Account.Logout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[SecurityHeaders]
[AllowAnonymous]
public class LoggedOutModel : PageModel
{
    private readonly IIdentityServerInteractionService _interactionService;
        
    public LoggedOutViewModel View { get; set; }

    public LoggedOutModel(IIdentityServerInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task OnGet(string logoutId)
    {
        // get context information (client name, post logout redirect URI and iframe for federated signout)
        var logout = await _interactionService.GetLogoutContextAsync(logoutId);

        View = new LoggedOutViewModel
        {
            AutomaticRedirectAfterSignOut = LogoutOptions.AutomaticRedirectAfterSignOut,
            PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
            ClientName = String.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
            SignOutIframeUrl = logout?.SignOutIFrameUrl
        };
    }
}