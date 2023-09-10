using System.Reflection;

using Amrita.IdentityManager.Host;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        false, true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddCommandLine(args);

builder.InstallServices(builder.Configuration, builder.Environment);
var app = builder.Build();

#region "Seeding"
var seed = builder.Configuration.GetValue<bool>("seed");
if (seed)
{
    var superAdminPwd = builder.Configuration.GetValue<string>("super-admin-pwd");
    if (!string.IsNullOrEmpty(superAdminPwd))
    {
        Log.Information("Seeding database...");
        Seeder.EnsureSeedData(app, superAdminPwd);
        Log.Information("Done seeding. Exiting...");
    }
    else
    {
        Log.Information("Please try with a super admin pwd. Exiting...");
    }
    
    return;
}
#endregion

app.ChainPipelines(builder.Configuration, builder.Environment);
app.Run();