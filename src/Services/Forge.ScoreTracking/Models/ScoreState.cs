namespace Forge.ScoreTracking.Models;

/// <summary>
/// Represents the state of a score.
/// </summary>
public class ScoreState
{
    public Guid MatchId { get; set; }
    public int Total { get; set; }
}
