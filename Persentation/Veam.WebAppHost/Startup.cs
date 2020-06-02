using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.IO;
using Veam.Web;

namespace Veam
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }
        public IWebHostEnvironment env { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(o =>
            o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            //services.AddControllers().AddJsonOptions(jsonOptions =>
            //{
            //    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            //});

            services.AddVeam(Configuration);

            services.AddControllersWithViews();
           // .AddRazorRuntimeCompilation();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app/*, IHostingEnvironment env*/)
        {
            if (env.IsDevelopment())
            {
               app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
             //  app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                //You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
           // app.UseVeamStaticFile(Configuration);
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
            });

        }

   
    }
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseVeamStaticFile(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var LocalRootPath = Configuration.GetSection("FileRootPath").Value;
            //  app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(LocalRootPath)

            });
            app.UseCookiePolicy();


            return app;//.UseMiddleware<MyMiddleware>();
        }
    }
}
