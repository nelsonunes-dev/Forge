using Forge.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Persistence.Sqlite;

public class SqliteModule : IModule
{
    public void RegisterModule(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<ForgeSqliteDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
    }
}
