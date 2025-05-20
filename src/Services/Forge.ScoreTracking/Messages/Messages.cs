using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking.Messages;

/// <summary>
/// Request model for updating the score.
/// </summary>
/// <param name="MatchId"></param>
/// <param name="Points"></param>
public record UpdateScore(Guid MatchId, int Points);

/// <summary>
/// Response model for getting the score.
/// </summary>
/// <param name="MatchId"></param>
/// <param name="NewScore"></param>
public record ScoreUpdated(Guid MatchId, int NewScore);