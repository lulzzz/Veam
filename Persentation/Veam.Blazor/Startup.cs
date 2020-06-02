using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Veam.Blazor.Data;
using Veam.Web;

namespace Veam.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddControllers().AddNewtonsoftJson(o =>
          o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()); 
            services.AddVeam(Configuration);

            services.AddControllersWithViews();
            // .AddRazorRuntimeCompilation();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseVeamStaticFile(Configuration);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseVeamStaticFile(this IApplicationBuilder app, IConfiguration Configuration)
        {
            //  var LocalRootPath = Configuration.GetSection("FileRootPath").Value;
            ////  app.UseStaticFiles();
            //  app.UseStaticFiles(new StaticFileOptions()
            //  {
            //      FileProvider = new PhysicalFileProvider(LocalRootPath)

            //  });
            //  app.UseCookiePolicy();


            return app;//.UseMiddleware<MyMiddleware>();
        }
    }
}
