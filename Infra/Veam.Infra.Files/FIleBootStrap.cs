using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.Services;

namespace Veam.Infra.Files
{
    public static class FIleBootStrap
    {
        public static IServiceCollection AddCustomFileService(this IServiceCollection services, IConfiguration Configuration)
        {
            //for File Upload
            services.AddTransient<IFileService, FileSerivce>();

            services.AddVeamFileServices(Configuration);

          
            return services;
        }
    }
}
