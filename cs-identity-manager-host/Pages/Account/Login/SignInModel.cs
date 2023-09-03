namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using System.ComponentModel.DataAnnotations;

public class SignInModel
{
    [Required(ErrorMessage = "User name id required")] public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Password id required")] public string Password { get; set; } = null!;

    public bool RememberLogin { get; set; }

    public string? ReturnUrl { get; set; }
}