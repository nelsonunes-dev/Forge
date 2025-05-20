using FastEndpoints;
using FastEndpoints.Swagger;
using Forge.Core.Extensions;
using Forge.Infrastructure.Extensions;
using Forge.MatchSimulation;
using Forge.Persistence.Extensions;
using Forge.Persistence.Sqlite.Extensions;

namespace Forge.Api.Extensions;

/// <summary>
/// Extension methods for registering the Forge API services.
/// </summary>
public static class ApiServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Forge API services with the specified configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddForgeApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddForgeCore(configuration);
        
        services.AddForgeInfrastructure();
        
        services.AddForgePersistence(configuration)
                .AddForgeSqlitePersistence(configuration);

        services.AddForgeMatchSimulation(configuration);

        // Register all modules
        services.RegisterModules(configuration);

        // Add FastEndpoints
        services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                    o.DocumentSettings = s =>
                    {
                        s.Title = "Forge Unified API";
                        s.Version = "v1";
                        s.Description = "Unified API surface for Forge.";
                    };
                });

        // Add minimal API services (for OpenAPI if needed later)
        services.AddEndpointsApiExplorer();

        return services;
    }

    /// <summary>
    /// Configures the Forge API middleware.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseForgeApi(this IApplicationBuilder app)
    {
        app.UseFastEndpoints()
            .UseSwaggerGen();

        return app;
    }
}
