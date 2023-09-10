namespace Amrita.IdentityManager.Application.UseCases.Account.Models;

public class RegistrationResponseModel : LoginResponseModel
{
    public Dictionary<string, string> Errors { get; set; } = new();
}