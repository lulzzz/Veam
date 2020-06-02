using Microsoft.Extensions.DependencyInjection;
using Veam.FileStorage.Abstractions;

namespace Veam.FileStorage.FileSystem
{
    public static class LocalFileStorage
    {
        public static IServiceCollection VeamLocalFileServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorage, FileStorage>();
            services.AddScoped<IDirectoryProxy, DirectoryProxy>();
            services.AddScoped<IFileProxy, FileProxy>();
            return services;
        }

    }
}
