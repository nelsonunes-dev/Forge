﻿using Akka.Actor;
using FastEndpoints;
using Forge.MatchSimulation.Messages;
using Forge.MatchSimulation.Requests;
using Forge.MatchSimulation.Responses;

namespace Forge.MatchSimulation.Endpoints;

/// <summary>
/// Endpoint for starting a match.
/// </summary>
public class StartMatchEndpoint : Endpoint<StartMatchRequest, StartMatchResponse>
{
    private readonly IActorRef _matchActor;

    /// <summary>
    /// Initializes a new instance of the <see cref="StartMatchEndpoint"/> class.
    /// </summary>
    /// <param name="matchActor"></param>
    public StartMatchEndpoint(IActorRef matchActor)
    {
        _matchActor = matchActor;
    }

    /// <summary>
    /// Configures the endpoint.
    /// </summary>
    public override void Configure()
    {
        Post("/actors/start-match");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the request to start a match.
    /// </summary>
    /// <param name="req"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public override async Task HandleAsync(StartMatchRequest req, CancellationToken ct)
    {
        var response = await _matchActor.Ask<MatchStarted>(new StartMatch(req.MatchId), cancellationToken: ct);

        await SendAsync(new StartMatchResponse
        {
            MatchId = response.MatchId,
            Status = "Started"
        });
    }
}
