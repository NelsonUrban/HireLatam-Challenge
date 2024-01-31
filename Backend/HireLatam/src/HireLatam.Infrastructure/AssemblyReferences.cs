using HireLatam.Domain.Todos;
using HireLatam.Infrastructure.Contexts;
using HireLatam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HireLatam.Infrastructure;

public static class AssemblyReferences
{
    private static string CONNECTION_STRING = "DefaultConnection";
    public static IServiceCollection Infrastructue(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(CONNECTION_STRING)!;

        services.AddCustomDbContext<TodoContext>(connectionString);
        services.AddTransient<ITodoRepository, TodoRepository>();

        return services;
    }

    private static IServiceCollection AddCustomDbContext<TContext>(
        this IServiceCollection services,
        string connectionString) where TContext : DbContext
    {
        var schema = typeof(TContext).Name.Contains("Context")
            ? typeof(TContext).Name.Replace("Context", "")
            : typeof(TContext).Name;

        services.AddDbContext<TContext>(options =>
            options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsHistoryTable($"_EfMigrations_{schema}", schema);
            }),
            ServiceLifetime.Transient,
            ServiceLifetime.Scoped);

        return services;
    }
}
