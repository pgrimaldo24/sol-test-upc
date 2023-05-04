using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerApplication
{
    public static class ApplicationIOC
    {
        public static IServiceCollection AddApplicationServiceRegistrationExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
