using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veam.Application.Core;
using Veam.Base.Action;
using Veam.CenterRent.Action;
using Veam.Centers.Action;
using Veam.EAM.Action;
using Veam.EAM.Data;
using Veam.Identity;
using Veam.Infra.Data;
using Veam.Infra.Emails;
using Veam.Infra.Files;

namespace Veam.Web
{
    public static class VeamCore
    {
        public static IServiceCollection AddVeam(this IServiceCollection services, IConfiguration Configuration)
        {
            
            services.AddCustomIdentity(Configuration);// all the Identity Configurarions
            services.AddCustomDataService(Configuration);
            services.AddEAMDataService(Configuration);
            services.AddCustomEmailService(Configuration);// all the Identity Configurarions
            services.AddCustomFileService(Configuration);// All File upload services
            services.AddBaseService(Configuration);
           
            services.AddEAMService(Configuration);
            // services.AddDDService();
            //services.AddEMSService();
            //services.AddEMSDataService(Configuration);
            //services
            //   .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
            //   .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //   .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBuildingCommandValidator>());

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            ///All Bounded Context Module
            services.AddCenterService();
            services.AddRentService();
            //Add Themes Folder

            //services.Configure<RazorViewEngineOptions>(o =>
            //{
            //    o.ViewLocationFormats.Clear();
            //    o.ViewLocationFormats.Add
            //  ("/Themes/{1}/{0}" + RazorViewEngine.ViewExtension);
            //    o.ViewLocationFormats.Add
            //  ("/Themes/Shared/Themes/{0}" + RazorViewEngine.ViewExtension);
            //});

            //mediatr  mediaTr should be register in last 
            services.AddApplicationCoreService();// All Mediatr notifications//
                                                 //  services.AddMediatR();
            return services;
        }
    }

 
}
