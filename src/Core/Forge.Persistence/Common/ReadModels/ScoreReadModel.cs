using Forge.Persistence.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Persistence.Common.ReadModels;

public class ScoreReadModel : IEntity
{
    public Guid Id { get; set; }
    public int TotalScore { get; set; }
}
