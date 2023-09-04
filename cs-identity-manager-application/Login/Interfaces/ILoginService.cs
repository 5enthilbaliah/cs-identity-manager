namespace Amrita.IdentityManager.Application.Login.Interfaces;

using Models;

public interface ILoginService
{
    Task<(SignInModel, LoginViewModel?)> BindModelsAsync(string returnUrl);
    Task<LoginResponseModel> SignInAsync(SignInModel signIn, Func<string, bool> localUrlCheck);
}