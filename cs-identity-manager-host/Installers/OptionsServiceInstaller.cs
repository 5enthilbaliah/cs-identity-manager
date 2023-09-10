namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

public class OptionsServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Options;

    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        hostBuilder.Services.Configure<ServiceSettings>(configuration.GetSection(nameof(ServiceSettings)));
    }
}