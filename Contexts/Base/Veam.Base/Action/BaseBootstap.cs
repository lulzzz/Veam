using Microsoft.Extensions.DependencyInjection;
using Veam.Base.Application;

namespace Veam.Base.Action
{
    public static class BaseBootstap
    {
        public static IServiceCollection AddBaseService(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorLineService, VendorLineService>();
            return services;
        }
    }
}