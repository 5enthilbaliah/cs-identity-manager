namespace Amrita.IdentityManager.Application.Login.Interfaces;

using Models;

public interface IRegistrationService
{
    Task<RegistrationResponseModel> RegisterCustomerAsync(SignUpModel signUp, Func<string, bool> localUrlCheck);
}