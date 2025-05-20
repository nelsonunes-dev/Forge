using Forge.Persistence.Common.Abstractions;
using Forge.Persistence.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Forge.Persistence.Common;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly ForgeSqliteDbContext _db;

    public Repository(ForgeSqliteDbContext db)
    {
        _db = db;
    }

    public Task<T?> GetAsync(Guid id, CancellationToken ct = default)
        => _db.Set<T>().FindAsync(new object?[] { id }, ct).AsTask();

    public Task<List<T>> GetAllAsync(CancellationToken ct = default)
        => _db.Set<T>().ToListAsync(ct);

    public Task AddAsync(T entity, CancellationToken ct = default)
        => _db.Set<T>().AddAsync(entity, ct).AsTask();

    public Task SaveChangesAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);

    public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
        => await _db.Set<T>().FindAsync(new object[] { id }, ct) is not null;

    public async Task UpsertAsync(T entity, CancellationToken ct = default)
    {
        if (await ExistsAsync(entity.Id, ct))
            _db.Set<T>().Update(entity);
        else
            await _db.Set<T>().AddAsync(entity, ct);

        await _db.SaveChangesAsync(ct);
    }
}
