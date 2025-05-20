namespace Forge.ScoreTracking.Requests;

/// <summary>
/// Request model for getting the score.
/// </summary>
public class GetScoreRequest
{
    public Guid MatchId { get; set; }
}
