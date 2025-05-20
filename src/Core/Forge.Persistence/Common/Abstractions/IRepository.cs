namespace Forge.Persistence.Common.Abstractions;

public interface IRepository<T> where T : class, IEntity
{
    Task<T?> GetAsync(Guid id, CancellationToken ct = default);
    Task<List<T>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
    Task UpsertAsync(T entity, CancellationToken ct = default);
}
