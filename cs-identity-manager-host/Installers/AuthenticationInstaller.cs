namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

public class AuthenticationInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Authentication;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.AddAuthentication();
    }
}