using Akka.Actor;
using Forge.MatchSimulation.Messages;

namespace Forge.MatchSimulation.Actors;

public class MatchSimulatorActor : ReceiveActor
{
    public MatchSimulatorActor()
    {
        Receive<StartMatch>(msg =>
        {
            Console.WriteLine($"🎮 Match started: {msg.MatchId}");
            Sender.Tell(new MatchStarted(msg.MatchId));
        });

        Receive<StopMatch>(msg =>
        {
            Console.WriteLine($"🛑 Match stopped: {msg.MatchId}");
            Sender.Tell(new MatchStopped(msg.MatchId));
        });
    }
}
