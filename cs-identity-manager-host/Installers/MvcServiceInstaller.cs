namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

using Presentation;

public class MvcServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Mvc;

    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        hostBuilder.Services.AddRazorPages()
            .AddApplicationPart(typeof(PresentationModule).Assembly);
    }
}