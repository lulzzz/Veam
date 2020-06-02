using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veam.Services
{
    public interface IFileService
    {
        Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env);
        Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env, string rootfolderurl, string folder);
        Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env, string folder);
    }
}
