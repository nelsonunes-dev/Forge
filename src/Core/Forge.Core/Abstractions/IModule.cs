using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Core.Abstractions;

/// <summary>
/// Defines a module that can be registered with the dependency injection container.
/// </summary>
public interface IModule
{
    /// <summary>
    /// Registers the module with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    void RegisterModule(IServiceCollection services, IConfiguration config);
}
