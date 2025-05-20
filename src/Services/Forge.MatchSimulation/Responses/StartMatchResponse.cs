namespace Forge.MatchSimulation.Responses;

public class StartMatchResponse
{
    public Guid MatchId { get; set; }
    public string Status { get; set; } = default!;
}
