using Dominio.IRepositorio;
using Infra.Contexto;
using Infra.Persistencia;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Configuracao
{
    public static class InjecoesDependenciasConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<IAtaRepositorio, AtaRepositorio>();


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            return services;
        }
    }
}
