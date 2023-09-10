namespace Amrita.IdentityManager.Application.Login.Models;

public class RegistrationResponseModel : LoginResponseModel
{
    public Dictionary<string, string> Errors { get; set; } = new();
}