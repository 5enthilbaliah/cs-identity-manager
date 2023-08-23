namespace Amrita.IdentityManager.Host.Pipelines;

using Enums;

using Interfaces;

public class StaticFilePipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.StaticFiles;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseStaticFiles();
    }
}