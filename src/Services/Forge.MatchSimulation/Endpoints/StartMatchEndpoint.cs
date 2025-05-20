using Akka.Actor;
using FastEndpoints;
using Forge.MatchSimulation.Messages;
using Forge.MatchSimulation.Requests;
using Forge.MatchSimulation.Responses;

namespace Forge.MatchSimulation.Endpoints;

public class StartMatchEndpoint : Endpoint<StartMatchRequest, StartMatchResponse>
{
    private readonly IActorRef _matchActor;

    public StartMatchEndpoint(IActorRef matchActor)
    {
        _matchActor = matchActor;
    }

    public override void Configure()
    {
        Post("/actors/start-match");
        AllowAnonymous();
    }

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
