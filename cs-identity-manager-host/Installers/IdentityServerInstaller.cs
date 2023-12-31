﻿namespace Amrita.IdentityManager.Host.Installers;

using Application;

using Domain;

using Enums;

using Infrastructure.Persistence;

using Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class IdentityServerInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.IdentityServer;

    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        var connectionSting = configuration.GetConnectionString("AmritaTribeDb");
        hostBuilder.Services.AddDbContext<AmritaTribeApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionSting);
        });
        hostBuilder.Services.AddIdentity<AmritaUser, IdentityRole>()
            .AddEntityFrameworkStores<AmritaTribeApplicationDbContext>()
            .AddDefaultTokenProviders();

        hostBuilder.Services.AddIdentityServer(options =>
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
        }).AddAspNetIdentity<AmritaUser>()
        .AddDeveloperSigningCredential()
        .AddProfileService<ProfileService>();
    }
}