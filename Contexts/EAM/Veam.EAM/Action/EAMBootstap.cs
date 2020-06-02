
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Veam.EAM.Application;
using Veam.Infra.QRCoder;

namespace Veam.EAM.Action
{
    public static class EAMBootstap
    {


        public static IServiceCollection AddEAMService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ICheckOutServices, CheckOutService>();
            services.AddScoped<IAssetPurchaseServices, AssetPurchaseService>();
            services.AddScoped<IAssetServices, AssetService>();
            services.AddQrService(options =>
            {
                options.Url = Configuration.GetSection("QrSettings").GetSection("Url").Value;
            });
            return services;
        }
    }
}