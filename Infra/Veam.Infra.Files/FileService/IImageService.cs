using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Barebone.Services
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile imageToUpload);
    }
}