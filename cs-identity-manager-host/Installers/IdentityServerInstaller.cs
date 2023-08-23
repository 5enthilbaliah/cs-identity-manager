namespace Amrita.IdentityManager.Host.Installers;

using Domain;

using Enums;

using Infrastructure.Persistence;

using Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class IdentityServerInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.IdentityServer;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        var connectionSting = configuration.GetConnectionString("AmritaTribeDb");
        services.AddDbContext<AmritaTribeApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionSting);
        });
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AmritaTribeApplicationDbContext>();

        services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;

            options.EmitStaticAudienceClaim = true;
        }).AddConfigurationStore<AmritaTribeConfigurationDbContext>(options =>
        {
            options.Setup();
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(connectionSting);
        }).AddOperationalStore<AmritaTribeOperationDbContext>(options =>
        {
            options.Setup();
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(connectionSting);
        }).AddAspNetIdentity<IdentityUser>();
    }
}