using Domain.IRepositories;
using Domain.Notifications;
using Domain.Notifications.Interface;
using Infra.Contexto;
using Infra.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

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


            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;

            }).AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

            services.AddAuthorization();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/User/Login/";
                options.LogoutPath = "/Home/Index/";
                options.SlidingExpiration = true;
            });


            return services;
        }
    }
}
