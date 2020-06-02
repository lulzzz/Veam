using Microsoft.Extensions.DependencyInjection;
using System;

namespace Veam.Infra.QRCoder
{
    public static class QrBootstrap
    {
        public static IServiceCollection AddQrService(this IServiceCollection services, Action<QrModel> options)
        {

            services.AddTransient<IQrCode, QrCode>();
           // services.AddTransient<IQRCoderManager, QRCoderManager>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options),
                    @"Please provide options for QRCode, Url.");
            }
            services.Configure(options);
            return services;
        }

    }
}
