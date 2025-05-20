using Akka.Actor;
using Forge.MatchSimulation.Messages;
using Forge.ScoreTracking.Messages;

namespace Forge.MatchSimulation.Actors;

/// <summary>
/// Actor for simulating match events.
/// </summary>
public class MatchSimulatorActor : ReceiveActor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MatchSimulatorActor"/> class.
    /// </summary>
    public MatchSimulatorActor()
    {
        Receive<StartMatch>(msg =>
        {
            Console.WriteLine($"Match started: {msg.MatchId}");
            Context.System.EventStream.Publish(new UpdateScore(msg.MatchId, 1));
            Sender.Tell(new MatchStarted(msg.MatchId));
        });

        Receive<StopMatch>(msg =>
        {
            Console.WriteLine($"Match stopped: {msg.MatchId}");
            Sender.Tell(new MatchStopped(msg.MatchId));
        });
    }
}
