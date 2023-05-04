using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sol.Pierr.Grimaldo.CrossCutting.Common.AppSetting;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Connection
{
    public static class DbExtension
    {
        public static IServiceCollection AddDBConfigurationExtension(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<DataContext>(options => options.UseOracle(
                string.Format("Data Source={0};User ID={1};Password={2};Connection Timeout=600;min pool size=0;connection lifetime=18000;PERSIST SECURITY INFO=True;DBA Privilege=SYSDBA",
                appSettings.OrclCredentials.DataSource, 
                appSettings.OrclCredentials.UserId,
                appSettings.OrclCredentials.Password)));
            return services;
        }
    }
}
