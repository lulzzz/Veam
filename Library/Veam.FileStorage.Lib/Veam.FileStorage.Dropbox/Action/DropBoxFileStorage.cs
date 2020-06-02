using Microsoft.Extensions.DependencyInjection;
using Veam.FileStorage.Abstractions;

namespace Veam.FileStorage.Dropbox
{
    public static class DropBoxFileStorage
    {
        public static IServiceCollection VeamDropBoxServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorage, FileStorage>();
            services.AddScoped<IDirectoryProxy, DirectoryProxy>();
            services.AddScoped<IFileProxy, FileProxy>();
            return services;
        }

    }
}
