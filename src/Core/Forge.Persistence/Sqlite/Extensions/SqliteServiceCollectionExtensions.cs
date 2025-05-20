using Forge.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Persistence.Sqlite.Extensions;

public static class SqliteServiceCollectionExtensions
{
    public static IServiceCollection AddForgeSqlitePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IModule, SqliteModule>();

        return services;
    }
}
