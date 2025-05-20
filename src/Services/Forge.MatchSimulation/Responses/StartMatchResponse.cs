namespace Forge.MatchSimulation.Responses;

/// <summary>
/// Response model for starting a match.
/// </summary>
public class StartMatchResponse
{
    public Guid MatchId { get; set; }
    public string Status { get; set; } = default!;
}
