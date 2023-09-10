namespace Amrita.IdentityManager.Application.UseCases.Account;

using System.Security.Claims;

using Domain;

using IdentityModel;

using Microsoft.AspNetCore.Identity;

using Models;

using UseCaseExecutR.Interfaces;

public record RegistrationUseCase(SignUpModel SignUp, Func<string, bool> LocalUrlCheck) :
    IUseCase<RegistrationResponseModel>
{
    public RegistrationResponseModel Vm { get; set; } = null!;
}

public class RegistrationUseCaseRunner : IUseCaseRunner<RegistrationUseCase, RegistrationResponseModel>
{
    private readonly SignInManager<AmritaUser> _signInManager;
    private readonly UserManager<AmritaUser> _userManager;

    public RegistrationUseCaseRunner(UserManager<AmritaUser> userManager, SignInManager<AmritaUser> signInManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<RegistrationResponseModel> Run(RegistrationUseCase useCase, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByNameAsync(useCase.SignUp.EmailId) != null)
        {
            return new RegistrationResponseModel
            {
                LoginResponseType = LoginResponseType.Failed,
                RedirectUrl = useCase.SignUp.ReturnUrl,
                Errors = new Dictionary<string, string> { { "EmailId", "Email is already taken" } }
            };
        }

        var customer = new AmritaUser
        {
            UserName = useCase.SignUp.EmailId,
            Email = useCase.SignUp.EmailId,
            EmailConfirmed = true,
            FullName = useCase.SignUp.FullName,
            IsInternal = false
        };
        var result = await _userManager.CreateAsync(customer, useCase.SignUp.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(customer, IdentityManagerConstants.Customer);

            await _userManager.AddClaimsAsync(customer,
                new Claim[]
                {
                    new(JwtClaimTypes.Name, useCase.SignUp.FullName),
                    new(JwtClaimTypes.Email, useCase.SignUp.EmailId), new(JwtClaimTypes.Picture, "NA"),
                    new(JwtClaimTypes.Role, IdentityManagerConstants.Customer)
                });

            var loginResult =
                await _signInManager.PasswordSignInAsync(useCase.SignUp.EmailId, useCase.SignUp.Password, false, false);
            if (loginResult.Succeeded)
            {
                if (useCase.LocalUrlCheck(useCase.SignUp.ReturnUrl))
                {
                    return new RegistrationResponseModel
                    {
                        LoginResponseType = LoginResponseType.Redirect, RedirectUrl = useCase.SignUp.ReturnUrl
                    };
                }

                if (string.IsNullOrEmpty(useCase.SignUp.ReturnUrl))
                {
                    return new RegistrationResponseModel
                    {
                        LoginResponseType = LoginResponseType.Redirect, RedirectUrl = "~/"
                    };
                }

                // user might have clicked on a malicious link - should be logged
                throw new Exception("invalid return URL");
            }

            return new RegistrationResponseModel
            {
                LoginResponseType = LoginResponseType.Failed,
                RedirectUrl = useCase.SignUp.ReturnUrl,
                Errors = new Dictionary<string, string>
                {
                    { "Password", "Automatic login failure - contact administrator." }
                }
            };
        }

        return new RegistrationResponseModel
        {
            LoginResponseType = LoginResponseType.Failed,
            RedirectUrl = useCase.SignUp.ReturnUrl,
            Errors = new Dictionary<string, string>
            {
                { "Password", "Registration failure - contact administrator." }
            }
        };
    }
}