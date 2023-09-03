namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using System.ComponentModel.DataAnnotations;

public class SignInModel
{
    [Required] public string UserName { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;

    public bool RememberLogin { get; set; }

    public string? ReturnUrl { get; set; }
}