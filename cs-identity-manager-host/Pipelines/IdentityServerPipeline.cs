namespace Amrita.IdentityManager.Host.Pipelines;

using Enums;

using Interfaces;

public class IdentityServerPipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.IdentityServer;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseIdentityServer();
    }
}