using Akka.Actor;
using Akka.Configuration;
using Akka.DependencyInjection;
using Forge.Core.Abstractions;
using Forge.MatchSimulation.Actors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.MatchSimulation;

/// <summary>
/// Module for integrating Akka.NET with the Forge Match Simulation service.
/// </summary>
public class AkkaMatchModule : IModule
{
    /// <summary>
    /// Registers the module with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public void RegisterModule(IServiceCollection services, IConfiguration config)
    {
        // Configure DI-aware actor system
        services.AddSingleton(provider =>
        {
            var bootstrap = DependencyResolverSetup.Create(provider);

            var actorSystemSetup = BootstrapSetup.Create()
                .WithConfig(ConfigurationFactory.Load())
                .WithActorRefProvider(ProviderSelection.Local.Instance);
            
            var actorSystem = ActorSystem.Create("MatchSimulationSystem", actorSystemSetup.And(bootstrap));

            return actorSystem;
        });

        services.AddSingleton<IActorRef>(provider =>
        {
            var system = provider.GetRequiredService<ActorSystem>();
            var resolver = DependencyResolver.For(system);
            
            return system.ActorOf(resolver.Props<MatchSimulatorActor>(), "match-simulator");
        });
    }
}
