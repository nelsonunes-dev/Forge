using Forge.Core.Abstractions;
using Forge.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Infrastructure;

/// <summary>
/// Dependency injection extensions for the Forge.Infrastructure library.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers all modules that implement IModule with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeInfrastructure(this IServiceCollection services)
    {
        // Register all modules
        services.AddTransient<IModule, SerilogBootstrapper>();

        // Add other infrastructure services here
        return services;
    }
}
