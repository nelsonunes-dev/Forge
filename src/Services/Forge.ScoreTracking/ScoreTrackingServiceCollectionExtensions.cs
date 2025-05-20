using FastEndpoints;
using Forge.Core.Abstractions;
using Forge.ScoreTracking.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.ScoreTracking;

/// <summary>
/// Extension methods for registering the Forge Score Tracking service.
/// </summary>
public static class ScoreTrackingServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Forge Score Tracking service with the specified configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeScoreTracking(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints(o =>
        {
            o.SourceGeneratorDiscoveredTypes.AddRange(typeof(GetScoreEndpoint).Assembly.GetTypes());
        });

        services.AddTransient<IModule, AkkaScoreModule>();

        return services;
    }
}
