namespace Amrita.IdentityManager.Host.Interfaces;

using Enums;

public interface IServiceInstaller
{
    InstallationOrder Order { get; }
    void Install(IServiceCollection services, IConfiguration configuration, string environment);
}