namespace Amrita.IdentityManager.Host.Installers;

using Enums;

using Interfaces;

using Serilog;

public class LoggerInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Logging;
    public void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment)
    {
        Log.Logger = new LoggerConfiguration()
            .CreateBootstrapLogger();
        
        hostBuilder.Host.UseSerilog((ctx, lc) =>
        {
            lc.ReadFrom.Configuration(configuration);
        });
    }
}