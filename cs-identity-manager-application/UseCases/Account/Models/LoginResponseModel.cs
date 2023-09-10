namespace Amrita.IdentityManager.Application.UseCases.Account.Models;

using Account;

public class LoginResponseModel
{
    public LoginResponseType LoginResponseType { get; set; }
    public string? RedirectUrl { get; set; }
}