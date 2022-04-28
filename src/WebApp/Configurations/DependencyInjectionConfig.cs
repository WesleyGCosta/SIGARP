using Dominio.IRepository;
using Infra.Persistencia;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAtaRepository, AtaRepository>();
            
            return services;
        }
    }
}
