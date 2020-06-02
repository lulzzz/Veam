using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Veam.Application.Core.Common;
using Veam.Application.Core.Infrastructure;
using Veam.Application.Core.Notifications;

namespace Veam.Application.Core
{
    /// <summary>
    /// mediaTr and and Basic Application Services Configured
    /// Automapper setting to work
    /// </summary>
    public static class ApplicationCoreBootStrap
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {


             //services.AddAutoMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //behaviour
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            // services.AddMediatR();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
// Add AutoMapper
//  services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
//services.AddAutoMapper(Assembly.GetExecutingAssembly());
//services.AddMediatR(Assembly.GetExecutingAssembly());
//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
// Add MediatR
// services.AddMediatR();
// services.AddMediatR(typeof(GetProductQueryHandler).GetTypeInfo().Assembly);
//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));