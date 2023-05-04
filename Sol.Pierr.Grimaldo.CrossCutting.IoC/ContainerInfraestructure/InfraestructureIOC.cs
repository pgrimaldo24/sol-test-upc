using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerInfraestructure
{
    public static class InfraestructureIOC
    {
        public static IServiceCollection AddInfraestructureServiceRegistrationExtension(this IServiceCollection services)
        {
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
     
            return services;
        }
    }
}
