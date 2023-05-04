using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sol.Pierr.Grimaldo.CrossCutting.Common.AppSetting;
using Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerApplication;
using Sol.Pierr.Grimaldo.CrossCutting.IoC.ContainerInfraestructure;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence.Connection;
using System;
using System.Data.Common;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.AddControllers();
            services.Configure<CookiePolicyOptions>(options =>
            { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddOptions();
            services.AddDistributedMemoryCache(); 
            services.AddApplicationServiceRegistrationExtension(Configuration);
            services.AddInfraestructureServiceRegistrationExtension();
            services.AddDBConfigurationExtension(appSettingsSection.Get<AppSettings>()); 
            services.Configure<AppSettings>(appSettingsSection);
            services.AddSingleton(x => x.GetService<IOptions<AppSettings>>().Value); 
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });  
            services.AddMemoryCache();   
        } 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.UseRouting(); 
            app.UseAuthorization(); 
            app.UseSession(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}");
            });
        }
    }
}
