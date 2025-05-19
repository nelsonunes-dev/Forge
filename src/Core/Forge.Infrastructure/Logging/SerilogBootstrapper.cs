using Forge.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Forge.Infrastructure.Logging;

/// <summary>
/// Bootstrapper for Serilog logging.
/// </summary>
public class SerilogBootstrapper : IModule
{
    /// <summary>
    /// Registers the Serilog module with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public void RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs/forge.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(Log.Logger, dispose: true));
    }
}
