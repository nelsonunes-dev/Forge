namespace Forge.MatchSimulation.Requests;

/// <summary>
/// Request model for starting a match.
/// </summary>
public class StartMatchRequest
{
    public Guid MatchId { get; set; }
}