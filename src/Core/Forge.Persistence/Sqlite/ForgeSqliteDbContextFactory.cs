using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Forge.Persistence.Sqlite;

public class ForgeSqliteDbContextFactory : IDesignTimeDbContextFactory<ForgeSqliteDbContext>
{
    public ForgeSqliteDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ForgeSqliteDbContext>();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));

        return new ForgeSqliteDbContext(optionsBuilder.Options);
    }
}
