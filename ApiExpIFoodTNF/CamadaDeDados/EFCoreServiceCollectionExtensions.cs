using CamadaDeDados.Interface;
using CamadaDeNegócios.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace CamadaDeDados;

public static class EFCoreServiceCollectionExtensions { 
    public static IServiceCollection AddEFCore(this IServiceCollection services)
    {
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<ISegmentoRepository, SegmentoRepository>();
        services.AddScoped<IExpProdFoodRepository, ExpProdIFoodRepository>();


        return services;
    }
}