using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking.Models;

/// <summary>
/// Represents the state of a score.
/// </summary>
public class ScoreState
{
    public Guid MatchId { get; set; }
    public int Total { get; set; }
}
