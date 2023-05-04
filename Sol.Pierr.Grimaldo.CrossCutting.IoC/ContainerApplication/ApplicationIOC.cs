using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sol.Pierr.Grimaldo.Application.Implementations;
using Sol.Pierr.Grimaldo.Application.Interfaces;

namespace Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerApplication
{
    public static class ApplicationIOC
    {
        public static IServiceCollection AddApplicationServiceRegistrationExtension(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthApplication, AuthApplication>();
            services.AddTransient<ISolicitudPrestamoApplication, SolicitudPrestamoApplication>();
            return services;
        }
    }
}
