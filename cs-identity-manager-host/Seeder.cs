namespace Amrita.IdentityManager.Host;

using System.Security.Claims;

using Domain;

using Duende.IdentityServer.EntityFramework.Mappers;

using IdentityModel;

using Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using Serilog;

public class Seeder
{
    public static void EnsureSeedData(WebApplication app, string superAdminPwd)
    {
        using var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AmritaTribeConfigurationDbContext>();
        EnsureSeedData(context!);
        EnsureUsers(serviceScope, superAdminPwd);
    }
    
    private static void EnsureSeedData(AmritaTribeConfigurationDbContext context)
    {
        if (!context.Clients.Any())
        {
            Log.Debug("Clients being populated");
            foreach (var client in SeedData.Clients)
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }
        
        if (!context.IdentityResources.Any())
        {
            Log.Debug("IdentityResources being populated");
            foreach (var resource in SeedData.IdentityResources)
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
        
        if (!context.ApiScopes.Any())
        {
            Log.Debug("ApiScopes being populated");
            foreach (var resource in SeedData.ApiScopes)
            {
                context.ApiScopes.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
        
        if (!context.ApiResources.Any())
        {
            Log.Debug("ApiResources being populated");
            foreach (var resource in SeedData.ApiResources.ToList())
            {
                context.ApiResources.Add(resource.ToEntity());
            }

            context.SaveChanges();
        }
    }

    private static void EnsureUsers(IServiceScope scope, string superAdminPwd)
    {
        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AmritaUser>>();
        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var svcSettingOptions = scope.ServiceProvider.GetRequiredService<IOptions<ServiceSettings>>();
        var svcSettings = svcSettingOptions!.Value;

        if (roleMgr.FindByNameAsync(SeedData.SuperAdminRole).Result == null)
        {
            roleMgr.CreateAsync(new IdentityRole(SeedData.SuperAdminRole)).GetAwaiter().GetResult();
        }
        
        if (roleMgr.FindByNameAsync(SeedData.CustomerRole).Result == null)
        {
            roleMgr.CreateAsync(new IdentityRole(SeedData.CustomerRole)).GetAwaiter().GetResult();
        }
        
        var superAdmin = userMgr.FindByNameAsync("super-administrator").Result;
        if (superAdmin == null)
        {
            superAdmin = new AmritaUser()
            {
                UserName = "super-administrator",
                FullName = "Super administrator",
                Email = $"super-administrator@{svcSettings.DefaultDomain}",
                IsInternal = true,
                EmailConfirmed = true,
            };
            var result = userMgr.CreateAsync(superAdmin, superAdminPwd).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            userMgr.AddToRoleAsync(superAdmin, SeedData.SuperAdminRole).GetAwaiter().GetResult();
            result = userMgr.AddClaimsAsync(superAdmin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, "Super administrator"),
                new Claim(JwtClaimTypes.GivenName, "NA"),
                new Claim(JwtClaimTypes.FamilyName, "NA"),
                new Claim(JwtClaimTypes.Picture, "NA"),
                new Claim(JwtClaimTypes.Role, SeedData.SuperAdminRole)
            }).Result;
            
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            Log.Debug("super-admin created");
        }
        else
        {
            Log.Debug("super-admin already exists");
        }
    }
}