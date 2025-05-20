namespace Forge.MatchSimulation.Messages;

/// <summary>
/// Message to start a match.
/// </summary>
/// <param name="MatchId"></param>
public record StartMatch(Guid MatchId);

/// <summary>
/// Message to stop a match.
/// </summary>
/// <param name="MatchId"></param>
public record StopMatch(Guid MatchId);

/// <summary>
/// Message indicating that a match has started.
/// </summary>
/// <param name="MatchId"></param>
public record MatchStarted(Guid MatchId);

/// <summary>
/// Message indicating that a match has stopped.
/// </summary>
/// <param name="MatchId"></param>
public record MatchStopped(Guid MatchId);
