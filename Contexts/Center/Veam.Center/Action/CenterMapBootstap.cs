using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Veam.Centers.Application;
using Veam.Centers.Center;

namespace Veam.Centers.Action
{
    public static class CenterMapBootstap
    {

        
        public static IServiceCollection AddCenterService(this IServiceCollection services)
        {
            services.AddScoped<ICenterService, CenterService>();
            services.AddScoped<ICenterReadService, CenterReadService>();
            services.AddScoped<IHallService, HallService>();
            return services;
        }
    }
}
//automapper from application layer not Working in Application Core Layer
//if (services == null) throw new ArgumentNullException(nameof(services));
//services.AddAutoMapper(typeof(AutoMapperConfig));
//AutoMapperConfig.RegisterMappings();
//Register Services
//services.AddMediatR(typeof(AddBuildingCommand).GetTypeInfo().Assembly);
