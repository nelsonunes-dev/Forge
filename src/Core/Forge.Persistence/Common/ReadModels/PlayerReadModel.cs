using Forge.Persistence.Common.Abstractions;

namespace Forge.Persistence.Common.ReadModels;

public class PlayerReadModel : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Score { get; set; }
}
