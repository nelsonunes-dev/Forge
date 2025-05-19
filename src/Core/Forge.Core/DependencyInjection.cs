using Forge.Core.Abstractions;
using Forge.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Forge.Core;

/// <summary>
/// Dependency injection extensions for the Forge.Core library.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers all modules that implement IModule with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeCore(this IServiceCollection services, IConfiguration configuration)
    {
        // Add other core services here
        services.AddForgeCoreLogging(configuration);

        return services;
    }

    /// <summary>
    /// Configures the logger using the provided configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeCoreLogging(this IServiceCollection services, IConfiguration configuration)
    {
        LoggingConfigurator.AddLogger(configuration);

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(dispose: true);
        });

        return services;
    }
}
