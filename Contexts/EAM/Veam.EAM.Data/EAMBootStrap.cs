using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veam.Application.Core;
using Veam.Data; 
using Veam.EAM.Application;

namespace Veam.EAM.Data
{
    public static class EAMBootStrap
    {
        public static IServiceCollection AddEAMDataService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EAMDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("TestConnection"))); 
            services.AddTransient<IEAMDbContext, EAMDbContext>();
            services.AddScoped<IEAmDropDownServices, EAMDropDownServices>();

            return services;
        }
    }
}
