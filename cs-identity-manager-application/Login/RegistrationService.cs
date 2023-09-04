namespace Amrita.IdentityManager.Application.Login;

using System.Security.Claims;

using Domain;

using IdentityModel;

using Interfaces;

using Microsoft.AspNetCore.Identity;

using Models;

public class RegistrationService : IRegistrationService
{
    private readonly UserManager<AmritaUser> _userManager;
    private readonly SignInManager<AmritaUser> _signInManager;

    public RegistrationService(UserManager<AmritaUser> userManager, SignInManager<AmritaUser> signInManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    // Not validating for customer role exists - It should exist
    public async Task<RegistrationResponseModel> RegisterCustomerAsync(SignUpModel signUp, Func<string, bool> localUrlCheck)
    {
        if (await _userManager.FindByNameAsync(signUp.UserName) != null)
        {
            return new RegistrationResponseModel
            {
                LoginResponseType = LoginResponseType.Failed,
                RedirectUrl = signUp.ReturnUrl,
                Errors = new Dictionary<string, string> { { "UserName", "User name is already taken" } }
            };
        }
        
        if (await _userManager.FindByEmailAsync(signUp.Email) != null)
        {
            return new RegistrationResponseModel
            {
                LoginResponseType = LoginResponseType.Failed,
                RedirectUrl = signUp.ReturnUrl,
                Errors = new Dictionary<string, string> { { "Email", "Email is already taken" } }
            };
        }
        
        var customer = new AmritaUser
        {
            UserName = signUp.UserName,
            Email = signUp.Email,
            EmailConfirmed = true,
            FullName = signUp.FullName,
            IsInternal = false,
        };
        var result = await _userManager.CreateAsync(customer, signUp.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(customer, IdentityManagerConstants.Customer);

            await _userManager.AddClaimsAsync(customer,
                new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, signUp.FullName), 
                    new Claim(JwtClaimTypes.Email, signUp.Email),
                    new Claim(JwtClaimTypes.Picture, "NA"),
                    new Claim(JwtClaimTypes.Role, IdentityManagerConstants.Customer)
                });

            var loginResult = await _signInManager.PasswordSignInAsync(signUp.UserName, signUp.Password, false, lockoutOnFailure:false);
            if (loginResult.Succeeded)
            {
                if (localUrlCheck(signUp.ReturnUrl))
                {
                    return new RegistrationResponseModel
                    {
                        LoginResponseType = LoginResponseType.Redirect, RedirectUrl = signUp.ReturnUrl
                    };
                }

                if (string.IsNullOrEmpty(signUp.ReturnUrl))
                {
                    return new RegistrationResponseModel { LoginResponseType = LoginResponseType.Redirect, RedirectUrl = "~/" };
                }
                
                // user might have clicked on a malicious link - should be logged
                throw new Exception("invalid return URL");
            }
            
            return new RegistrationResponseModel
            {
                LoginResponseType = LoginResponseType.Failed,
                RedirectUrl = signUp.ReturnUrl,
                Errors = new Dictionary<string, string> { { "Password", "Automatic login failure - contact administrator." } }
            };
        }
        
        return new RegistrationResponseModel
        {
            LoginResponseType = LoginResponseType.Failed,
            RedirectUrl = signUp.ReturnUrl,
            Errors = new Dictionary<string, string> { { "Password", "Registration failure - contact administrator." } }
        };
    }
}