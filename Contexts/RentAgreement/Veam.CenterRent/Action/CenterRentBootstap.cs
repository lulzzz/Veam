using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Veam.CenterRent.Application;

namespace Veam.CenterRent.Action
{
    public static class CenterRentBootstap
    {

        /// <summary>
        /// Auto Mapper are confiured here
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRentService(this IServiceCollection services)
        {
           // services.AddMediatR(typeof(AddBuildingCommand).GetTypeInfo().Assembly);
            services.AddScoped<IBuildingServices, BuildingService>();
           
            return services;
        }
    }
}
//automapper from application layer not Working in Application Core Layer
//if (services == null) throw new ArgumentNullException(nameof(services));
//services.AddAutoMapper(typeof(AutoMapperConfig));
//AutoMapperConfig.RegisterMappings();
//Register Services