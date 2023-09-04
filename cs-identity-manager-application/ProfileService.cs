namespace Amrita.IdentityManager.Application;

using System.Security.Claims;

using Amrita.IdentityManager.Domain;

using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

using IdentityModel;

using Microsoft.AspNetCore.Identity;

public class ProfileService : IProfileService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserClaimsPrincipalFactory<AmritaUser> _userClaimsPrincipalFactory;
    private readonly UserManager<AmritaUser> _userManager;

    public ProfileService(IUserClaimsPrincipalFactory<AmritaUser> userClaimsPrincipalFactory,
        UserManager<AmritaUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory ??
                                      throw new ArgumentNullException(nameof(userClaimsPrincipalFactory));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }


    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub!);

        var userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);
        var claims = userClaims.Claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type))
            .ToList();

        if (_userManager.SupportsUserRole)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userRoles.Select(role => new Claim(JwtClaimTypes.Role, role)));
        }
        
        context.AddRequestedClaims(claims);
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub!);
        context.IsActive = user is not null;
    }
}