namespace Amrita.IdentityManager.Host.Installers;

using Application;

using Duende.IdentityServer.Services;

using Enums;

using Interfaces;

public class ApplicationInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Application;
    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        hostBuilder.Services.AddUseCaseExecutR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ProfileService).Assembly);
        });
        
        hostBuilder.Services.AddScoped<IProfileService, ProfileService>();
    }
}