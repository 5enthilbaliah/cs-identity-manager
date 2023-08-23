namespace Amrita.IdentityManager.Host;

using Interfaces;

public static class HostExtensions
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        var serviceInstallers = typeof(Program).Assembly.ExportedTypes
            .Where(x => typeof(IServiceInstaller).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>()
            .OrderBy(x => (int)x.Order)
            .ToList();

        serviceInstallers.ForEach(installer =>
        {
            installer.Install(services, configuration, environment.EnvironmentName);
        });
    }

    public static void ChainPipelines(this IApplicationBuilder appBuilder, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        var pipelines = typeof(Program).Assembly.ExportedTypes
            .Where(x => typeof(IMiddlewarePipeline).IsAssignableFrom(x) &&
                        x is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IMiddlewarePipeline>()
            .OrderBy(x => (int)x.Step)
            .ToList();

        pipelines.ForEach(pipeline =>
        {
            pipeline.Pipe(appBuilder, configuration, environment.EnvironmentName);
        });
    }
}