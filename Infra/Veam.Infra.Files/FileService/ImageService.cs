using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Barebone.Services
{
    public class ImageService : IImageService
    {
        private readonly string accessKey;

        public ImageService(IConfiguration configuration)
        {
            this.accessKey = configuration.GetSection("AzureStorageConnectionString").ToString();
        }

        public async Task<string> UploadImageAsync(IFormFile imageToUpload)
        {
            string imageFullPath = null;
            if (imageToUpload == null || imageToUpload.Length == 0)
            {
                return null;
            }
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("bootcamp-images");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.OpenReadStream());

                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {

            }
            return imageFullPath;
        }
    }
}