namespace Forge.ScoreTracking.Responses;

/// <summary>
/// Response model for getting the score.
/// </summary>
public class GetScoreResponse
{
    public Guid MatchId { get; set; }
    public int Score { get; set; }
}
