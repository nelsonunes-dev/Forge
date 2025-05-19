using Forge.Api.Extensions;
using Forge.Core.Logging;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    builder.Services.AddForgeApi(builder.Configuration);

    var app = builder.Build();
    app.UseForgeApi();

    LoggingConfigurator.LogStartup("Forge API started successfully");
    app.Run();
}
catch(Exception ex)
{
    LoggingConfigurator.LogFatal(ex, "Forge API terminated unexpectedly");
}
finally
{
    LoggingConfigurator.Shutdown();
}
