using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Forge.Core.Logging;

/// <summary>
/// Logging configuration and setup.
/// </summary>
public static class LoggingConfigurator
{
    /// <summary>
    /// Configures the logger using the provided configuration.
    /// </summary>
    /// <param name="configuration"></param>
    public static void AddLogger(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            .CreateLogger();

        Log.Information("Logger configured successfully.");
    }

    /// <summary>
    /// Configures the logger for the web application builder.
    /// </summary>
    /// <param name="builder"></param>
    public static void UseLogger(WebApplicationBuilder builder)
    {
        AddLogger(builder.Configuration);
        builder.Host.UseSerilog();
    }

    /// <summary>
    /// Logs the startup of the application with the provided name.
    /// </summary>
    /// <param name="appName"></param>
    public static void LogStartup(string appName)
    {
        Log.Information("{App} started successfully.", appName);
    }

    /// <summary>
    /// Logs the shutdown of the application with the provided name.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="appName"></param>
    public static void LogFatal(Exception ex, string appName)
    {
        Log.Fatal(ex, "{App} terminated unexpectedly.", appName);
    }

    /// <summary>
    /// Closes and flushes the logger.
    /// </summary>
    public static void Shutdown()
    {
        Log.CloseAndFlush();
    }
}
