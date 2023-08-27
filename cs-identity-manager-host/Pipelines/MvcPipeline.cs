namespace Amrita.IdentityManager.Host.Pipelines;

using Enums;

using Interfaces;

public class MvcPipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.Mvc;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseRouting();
        app.UseAuthorization();
        (app as WebApplication)!.MapRazorPages();
            //.RequireAuthorization();
    }
}