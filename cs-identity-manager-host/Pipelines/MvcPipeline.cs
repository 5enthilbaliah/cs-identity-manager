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
        app.Use(async (context, next) => {
            context.Response.Headers.Add("Content-Security-Policy", "style-src 'self' https://fonts.googleapis.com; font-src 'self' https://fonts.gstatic.com;");
            await next();
        });
        (app as WebApplication)!.MapRazorPages();
        //.RequireAuthorization();
    }
}