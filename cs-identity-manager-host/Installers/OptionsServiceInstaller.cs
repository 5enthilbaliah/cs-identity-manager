namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

public class OptionsServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Options;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.Configure<ServiceSettings>(configuration.GetSection(nameof(ServiceSettings)));
    }
}