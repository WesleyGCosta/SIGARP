using Dominio.IRepository;
using Infra.Contexto;
using Infra.Persistencia;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAtaRepository, AtaRepository>();


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            return services;
        }
    }
}
