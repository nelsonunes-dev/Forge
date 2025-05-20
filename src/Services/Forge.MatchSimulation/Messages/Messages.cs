namespace Forge.MatchSimulation.Messages;

public record StartMatch(Guid MatchId);
public record StopMatch(Guid MatchId);

public record MatchStarted(Guid MatchId);
public record MatchStopped(Guid MatchId);
