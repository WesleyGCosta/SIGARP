using Domain.IRepositories;
using Domain.Notifications;
using Infra.Contexto;
using Infra.Persistencia;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Configuration
{
    public static class InjectionDependencyConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<IAtaRepository, AtaRepository>();
            services.AddScoped<INotifier, Notifier>();


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            return services;
        }
    }
}
