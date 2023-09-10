﻿namespace Amrita.IdentityManager.Host.Installers;

using Application;

using Duende.IdentityServer.Services;

using Enums;

using Interfaces;

public class ApplicationInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Application;
    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.AddScoped<IProfileService, ProfileService>();
    }
}