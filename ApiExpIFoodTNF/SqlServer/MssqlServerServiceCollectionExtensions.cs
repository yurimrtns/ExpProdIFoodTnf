using Microsoft.Extensions.DependencyInjection;
using CamadaDeDados;
using Microsoft.EntityFrameworkCore;


namespace SqlServer;

public static class MssqlServerServiceCollectionExtensions
{
    public static IServiceCollection AddEFCoreMssqlServer(this IServiceCollection services)
    {
        services.AddEFCore();

        services.AddTnfDbContext<ExpIFoodContext>(cfg => cfg.DbContextOptions.UseSqlite(cfg.ConnectionString));

        return services;
    }
}
