using Forge.Persistence.Common.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace Forge.Persistence.Sqlite;

public class ForgeSqliteDbContext : DbContext
{
    public ForgeSqliteDbContext(DbContextOptions<ForgeSqliteDbContext> options) : base(options) { }

    public DbSet<PlayerReadModel> Players => Set<PlayerReadModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForgeSqliteDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
