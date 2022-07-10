using Domain.IRepositories;
using Domain.Notifications;
using Domain.Notifications.Interface;
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
            services.AddScoped<IDetentoraRepository, DetentoraRepository>();
            services.AddScoped<IDetentoraItemRepository, DetentoraItemRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IParticipanteItemRepository, ParticipanteItemRepository>();
            services.AddScoped<IProgramacaoConsumoParticipanteRepository, ProgramacaoConsumoParticipanteRepository>();
            services.AddScoped<IUnidadeAdministrativaRepository, UnidadeAdministrativaRepository>();
            services.AddScoped<INotifier, Notifier>();


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            return services;
        }
    }
}
