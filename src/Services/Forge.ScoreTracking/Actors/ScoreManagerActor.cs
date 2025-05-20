using Akka.Actor;
using Forge.Persistence.Common.Abstractions;
using Forge.Persistence.Common.ReadModels;
using Forge.ScoreTracking.Messages;
using Forge.ScoreTracking.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking.Actors;

/// <summary>
/// Actor for managing scores.
/// </summary>
public class ScoreManagerActor : ReceiveActor
{
    private readonly Dictionary<Guid, ScoreState> _scores = new();
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreManagerActor"/> class.
    /// </summary>
    /// <param name="scopeFactory"></param>
    public ScoreManagerActor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        Context.System.EventStream.Subscribe(Self, typeof(UpdateScore));

        Receive<UpdateScore>(async msg =>
        {
            var state = _scores.TryGetValue(msg.MatchId, out var s)
                ? s
                : new ScoreState { MatchId = msg.MatchId };

            state.Total += msg.Points;
            _scores[msg.MatchId] = state;

            Console.WriteLine($"Score updated for Match {msg.MatchId}: {state.Total}");

            // persist to DB
            using var scope = _scopeFactory.CreateScope();
            var scoreReadModel = scope.ServiceProvider.GetRequiredService<IRepository<ScoreReadModel>>();

            var model = await scoreReadModel.GetAsync(msg.MatchId) ?? new ScoreReadModel { Id = msg.MatchId };
            model.TotalScore = state.Total;

            await scoreReadModel.UpsertAsync(model);
        });
    }
}
