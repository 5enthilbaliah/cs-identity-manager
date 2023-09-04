namespace Amrita.IdentityManager.Application.Login.Models;

public class LoginResponseModel
{
    public LoginResponseType LoginResponseType { get; set; }
    public string? RedirectUrl { get; set; }
}