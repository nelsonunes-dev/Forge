using FastEndpoints;
using Forge.Core.Abstractions;
using Forge.MatchSimulation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.MatchSimulation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddForgeMatchSimulation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints(o =>
        {
            // o.Assemblies = new[] {Assembly.GetExecutingAssembly() };
            o.SourceGeneratorDiscoveredTypes.AddRange(typeof(StartMatchEndpoint).Assembly.GetTypes());
        });

        services.AddTransient<IModule, AkkaMatchModule>();

        return services;
    }
}
