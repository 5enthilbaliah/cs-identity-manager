using System.Reflection;

using Amrita.IdentityManager.Host;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up...");

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        false, true)
    .AddUserSecrets(Assembly.GetExecutingAssembly());

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .WriteTo.Console(
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
            theme: AnsiConsoleTheme.Code)
        .Enrich.FromLogContext();
});

builder.Services.InstallServices(builder.Configuration, builder.Environment);
var app = builder.Build();

// if (args.Contains("/seed"))
// {
//     Log.Information("Seeding database...");
//     // SeedData.EnsureSeedData(app);
//     Log.Information("Done seeding. Exiting...");
//     return;
// }

app.ChainPipelines(builder.Configuration, builder.Environment);
app.Run();