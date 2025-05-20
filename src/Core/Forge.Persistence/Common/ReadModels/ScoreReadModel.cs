using Forge.Persistence.Common.Abstractions;

namespace Forge.Persistence.Common.ReadModels;

public class ScoreReadModel : IEntity
{
    public Guid Id { get; set; }
    public int TotalScore { get; set; }
}
