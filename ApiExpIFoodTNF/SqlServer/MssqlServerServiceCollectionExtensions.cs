using Microsoft.Extensions.DependencyInjection;
using CamadaDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace SqlServer;

public static class MssqlServerServiceCollectionExtensions
{
    private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
    public static IServiceCollection AddEFCoreMssqlServer(this IServiceCollection services)
    {
        services.AddEFCore();

        services.AddTnfDbContext<ExpIFoodContext>(cfg => cfg.DbContextOptions.UseSqlite(cfg.ConnectionString).EnableSensitiveDataLogging().UseLoggerFactory(_logger));

        return services;
    }
}
