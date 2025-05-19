using Forge.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Core.Extensions;

/// <summary>
/// Extension methods for registering modules with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all modules that implement IModule with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="forceLoadTypes"></param>
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration, params Type[] forceLoadTypes)
    {
        // Ensure referenced assemblies are loaded
        foreach (var type in forceLoadTypes)
        {
            _ = type.Assembly; // Load it into AppDomain
        }

        // Discover all IModule implementations
        var modules = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Distinct();

        foreach (var moduleType in modules)
        {
            var module = (IModule)Activator.CreateInstance(moduleType)!;
            module.RegisterModule(services, configuration);
        }
    }
}
