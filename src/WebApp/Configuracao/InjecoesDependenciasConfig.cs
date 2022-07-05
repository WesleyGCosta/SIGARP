using Domain.IRepositories;
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
            services.AddScoped<IAtaRepository, AtaRepository>();


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            return services;
        }
    }
}
