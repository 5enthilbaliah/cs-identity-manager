namespace Amrita.IdentityManager.Host.Pages.Account.Login;

using System.ComponentModel.DataAnnotations;

public class SignUpModel
{
    [Required] public string UserName { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
    
    [Required] public string Email { get; set; } = null!;
    
    [Required] public string FullName { get; set; } = null!;
}