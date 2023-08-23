namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

public class MvcServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Mvc;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.AddRazorPages();
    }
}