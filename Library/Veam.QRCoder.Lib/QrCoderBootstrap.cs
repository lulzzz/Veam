using Maple.NetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Veam.QRCoder.Lib;

namespace QRCodeBitmap
{
    public static class QrCoderBootstrap
    {
        public static IServiceCollection AddQrService(this IServiceCollection services, Action<QrModel> options)
        {

            services.AddTransient<IQrCode, QrCode>();
            services.AddTransient<IQRCoderManager, QRCoderManager>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options),
                    @"Please provide options for MyService.");
            }
            services.Configure(options);
            return services;
        }

    }
}
