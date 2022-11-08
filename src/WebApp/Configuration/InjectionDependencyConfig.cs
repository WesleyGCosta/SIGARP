using Domain.Entities;
using Domain.IRepositories;
using Domain.Notifications;
using Domain.Notifications.Interface;
using Infra.Contexto;
using Infra.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            services.AddScoped<IRealinhamentoPrecoRepository, RealinhamentoPrecoRepository>();
            services.AddScoped<INotifier, Notifier>();


            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;

            }).AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders()
            .AddPortugueseIdentityErrorDescriber();

            services.AddAuthorization();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "SIGARPCookieName";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/User/Login/";
                options.LogoutPath = "/Home/Index/";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.AccessDeniedPath = "/User/RestrictedAcess/";
                options.SlidingExpiration = true;
            });

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                       .RequireAuthenticatedUser()
                       .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            return services;
        }
    }
}
