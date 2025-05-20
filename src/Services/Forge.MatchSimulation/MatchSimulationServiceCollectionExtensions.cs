using FastEndpoints;
using Forge.Core.Abstractions;
using Forge.MatchSimulation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.MatchSimulation;

/// <summary>
/// Extension methods for registering the Forge Match Simulation service.
/// </summary>
public static class MatchSimulationServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Forge Match Simulation service with the specified configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeMatchSimulation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints(o =>
        {
            o.SourceGeneratorDiscoveredTypes.AddRange(typeof(StartMatchEndpoint).Assembly.GetTypes());
        });

        services.AddTransient<IModule, AkkaMatchModule>();

        return services;
    }
}
