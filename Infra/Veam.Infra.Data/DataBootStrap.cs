using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veam.Application.Core;
//using Veam.Barebone.Services;
using Veam.Base.Application;
using Veam.CenterRent.Application;
using Veam.Centers.Application;
using Veam.Data;
using Veam.EAM.Application;
using Veam.Services;

namespace Veam.Infra.Data
{
    public static class DataBootStrap
    {
        public static IServiceCollection AddCustomDataService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext< DataDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("CoreConnection")));
            // Add DI for DataDb Defaults Initialization        
            services.AddTransient<IDbInitService, DbInitService>();
            services.AddTransient<ICenterDbContext, DataDbContext>();
            services.AddTransient<IRentDbContext, DataDbContext>();
            services.AddTransient<IBaseDbContext, DataDbContext>();
            //services.AddTransient<IEAMDbContext, DataDbContext>();
            services.AddScoped<IBaseReadModelRepository, BaseReadModelRepository>();
            services.AddScoped<IDropDownServices, DropDownService>();

            return services;
        }
    }
}
