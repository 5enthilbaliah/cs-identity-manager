namespace Amrita.IdentityManager.Host.Interfaces;

using Enums;

public interface IServiceInstaller
{
    InstallationOrder Order { get; }
    void Install(WebApplicationBuilder hostBuilder, IConfiguration configuration, string environment);
}