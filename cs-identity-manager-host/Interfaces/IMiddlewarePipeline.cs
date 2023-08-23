namespace Amrita.IdentityManager.Host.Interfaces;

using Enums;

public interface IMiddlewarePipeline
{
    PipelineOrder Step { get; }
    void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment);
}