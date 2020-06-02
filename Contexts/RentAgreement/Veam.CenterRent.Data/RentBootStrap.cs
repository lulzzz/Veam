using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veam.CenterRent.Application;

namespace Veam.CenterRent.Data
{
    public static class EAMBootStrap
    {
        public static IServiceCollection AddEAMDataService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<RentDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
             
            //services.AddScoped<IRentDropDownServices, RentDropDownServices>();
            services.AddTransient<IRentDbContext, RentDbContext>();
            return services;
        }
    }
}
