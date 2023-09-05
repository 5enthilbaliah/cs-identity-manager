namespace Amrita.IdentityManager.Application.Login.Models;

using System.ComponentModel.DataAnnotations;

public class SignInModel
{
    [Required(ErrorMessage = "Email id is required")]
    [DataType(DataType.EmailAddress)]
    public string EmailId { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;

    public bool RememberLogin { get; set; }

    public string? ReturnUrl { get; set; }
}