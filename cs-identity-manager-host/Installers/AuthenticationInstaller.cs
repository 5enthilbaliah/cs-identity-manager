namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

public class AuthenticationInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Authentication;

    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        hostBuilder.Services.AddAuthentication();
    }
}