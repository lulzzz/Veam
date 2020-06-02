using EMS.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Veam.EMS.Domain;

namespace Veam.EMS
{
    public static class DataBootStrap
    {
        public static IServiceCollection AddEMSDataService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EmployeeContext>(c =>
               c.UseSqlServer(Configuration.GetConnectionString("EmployeeConnection")));
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            return services;
        }
    }
}
