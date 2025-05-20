using Akka.Actor;
using Akka.DependencyInjection;
using Forge.Core.Abstractions;
using Forge.ScoreTracking.Actors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking;

/// <summary>
/// Module for registering Akka.NET components.
/// </summary>
public class AkkaScoreModule : IModule
{
    /// <summary>
    /// Registers the module with the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public void RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(provider =>
        {
            var setup = DependencyResolverSetup.Create(provider);

            var bootstrap = BootstrapSetup.Create()
                .WithConfig(Akka.Configuration.ConfigurationFactory.Load())
                .WithActorRefProvider(ProviderSelection.Local.Instance);

            return ActorSystem.Create("ScoreTrackingSystem", bootstrap.And(setup));
        });

        services.AddSingleton<IActorRef>(provider =>
        {
            var system = provider.GetRequiredService<ActorSystem>();
            var resolver = DependencyResolver.For(system);

            return system.ActorOf(resolver.Props<ScoreManagerActor>(), "score-manager");
        });
    }
}
