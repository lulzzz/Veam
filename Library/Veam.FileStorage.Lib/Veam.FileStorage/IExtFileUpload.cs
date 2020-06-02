using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Veam.FileStorage.Abstractions;

namespace Veam.File 
{
   public interface IExtFileUpload
    {
        Task <string> UploadFile2(List<IFormFile> files,string dir);
        Task<fileResult> UploadFile(List<IFormFile> files, string dir);
        Task<fileResult> UploadFile(IFormFile file, string dir);
    }
    public class ExtFileUpload : IExtFileUpload
    {
        private readonly IFileStorage _fs;

        public ExtFileUpload(IFileStorage fs)
        {
            _fs = fs;
        }

        public async Task<string> UploadFile2(List<IFormFile> files, string dir)
        {
            var result = "";
            var UniqueName = "";

            IDirectoryProxy dirProxy = _fs.CreateDirectoryProxy(dir);
            if (!await dirProxy.ExistsAsync()) await dirProxy.CreateAsync();//create directory if not exist

            foreach (IFormFile file in files)
            {
                string name = Path.GetFileName(file.FileName);
                UniqueName = Guid.NewGuid().ToString() + "_" + name;
                IFileProxy fileProxy = this._fs.CreateFileProxy(dir, UniqueName); 
                if (!await fileProxy.ExistsAsync())// check if file exist
                {
                    await fileProxy.WriteStreamAsync(file.OpenReadStream());
                }
                result = UniqueName;
            }

            return result;
            
        }

        public async Task<fileResult> UploadFile(List<IFormFile> files, string dir)
        {

            var fr = new fileResult();

            IDirectoryProxy dirProxy = _fs.CreateDirectoryProxy(dir);
            if (!await dirProxy.ExistsAsync()) await dirProxy.CreateAsync();//create directory if not exist

            foreach (IFormFile file in files)
            {
                var str = Path.GetFileName(file.FileName);
                str = str.Replace(" ", "_");
                fr.tagName = str;//Path.GetFileName(file.FileName);
                fr.uniqueName = Guid.NewGuid().ToString() + "_" + fr.tagName;
                IFileProxy fileProxy = this._fs.CreateFileProxy(dir, fr.uniqueName);
                fr.fileSize = FormatSize(file.Length);
                if (!await fileProxy.ExistsAsync())// check if file exist
                {
                    await fileProxy.WriteStreamAsync(file.OpenReadStream());
                }

            }

            return fr;

        }

        // Load all suffixes in an array  
        private readonly string[] suffixes =
        { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        private string FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }

        public async Task<fileResult> UploadFile(IFormFile file, string dir)
        {
            var fr = new fileResult();

            IDirectoryProxy dirProxy = _fs.CreateDirectoryProxy(dir);
            if (!await dirProxy.ExistsAsync()) await dirProxy.CreateAsync();//create directory if not exist
             
                var str = Path.GetFileName(file.FileName);
                str = str.Replace(" ", "_");
                fr.tagName = str;//Path.GetFileName(file.FileName);
                fr.uniqueName = Guid.NewGuid().ToString() + "_" + fr.tagName;
                IFileProxy fileProxy = this._fs.CreateFileProxy(dir, fr.uniqueName);
                fr.fileSize = FormatSize(file.Length);
                if (!await fileProxy.ExistsAsync())// check if file exist
                {
                    await fileProxy.WriteStreamAsync(file.OpenReadStream());
                } 
            return fr;
        }
    }
    public class fileResult
    {
        public string tagName { get; set; }
        public string uniqueName { get; set; }
        public string fileSize { get; set; }
    }
}
