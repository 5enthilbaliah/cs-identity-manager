namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using System.ComponentModel.DataAnnotations;

public class SignUpModel
{
    [Required(ErrorMessage = "User name id required")] public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Password id required")] public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "Email required")] public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Full name id required")] public string FullName { get; set; } = null!;
}