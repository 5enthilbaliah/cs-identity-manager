namespace Amrita.IdentityManager.Application.UseCases.Account.Models;

using System.ComponentModel.DataAnnotations;

public class SignUpModel
{
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Email id is required")]
    [DataType(DataType.EmailAddress)]
    public string EmailId { get; set; } = null!;

    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; } = null!;

    public string? ReturnUrl { get; set; }
}