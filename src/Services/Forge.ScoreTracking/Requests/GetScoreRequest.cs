using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking.Requests;

/// <summary>
/// Request model for getting the score.
/// </summary>
public class GetScoreRequest
{
    public Guid MatchId { get; set; }
}
