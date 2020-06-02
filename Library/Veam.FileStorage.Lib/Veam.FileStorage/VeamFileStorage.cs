using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Veam.File;
using Veam.FileStorage;
using Veam.FileStorage.FileSystem;


namespace Veam
{

    public static class FileBootstrap
    {

        public static IServiceCollection AddVeamFileServices(this IServiceCollection services, IConfiguration Configuration)
        {
           ////for local storage
            services.VeamLocalFileServices(); 
            var LocalRootPath = Configuration.GetSection("FileRootPath").Value;
            services.Configure<FileStorageOptions>(options =>
            {
                // options.RootPath = @"C:\Users\dell\Pictures\Icard\Test";
                options.RootPath = @LocalRootPath;// from appsetting 
            });

            services.AddScoped<IExtFileUpload, ExtFileUpload>();
            ////for DropBox
            // services.VeamDropBoxServices();
            //services.Configure<FileStorageOptions>(options =>
            //{ 
            //   // for dropbox 
            //    options.Secret = "JsPyzBd-zkYAAAAAAAAAG8fLfljgi0uvx0sL3ZP-ffexJeliAON6nQ1fdtYcUcvd";
            //    options.RootPath = @"/"; 
            //});

            ////for GoogleDrive
            // services.VeamGoogleDriveServices();
            //services.Configure<FileStorageOptions>(options =>
            //{
            //    //for GogleDrive, yet to implement its services
            //    options.Secret = "AIzaSyClvaTlwXWuPTUWi45NXA0r1fktRkeaVy8"; //api key
            //    options.RootPath = @"/"; 
            //});

            return services;
        }
        public static IApplicationBuilder UseVeamStaticFile(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var LocalRootPath = Configuration.GetSection("FileRootPath").Value;
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(LocalRootPath)

            });

            return app; 
        }

    }
}
