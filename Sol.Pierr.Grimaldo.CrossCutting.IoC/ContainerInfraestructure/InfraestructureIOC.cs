using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations.Data;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces.Data;

namespace Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerInfraestructure
{
    public static class InfraestructureIOC
    {
        public static IServiceCollection AddInfraestructureServiceRegistrationExtension(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            return services;
        }
    }
}
