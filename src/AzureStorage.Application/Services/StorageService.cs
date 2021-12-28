using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureStorage.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobClient;
        private readonly List<string> files = new List<string>();

        public StorageService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }

        /// <summary>
        /// Get client for Azure Storage
        /// </summary>
        /// <param name="containerName">Name of container</param>
        private BlobContainerClient GetContainerClient(string containerName) =>
            _blobClient.GetBlobContainerClient(containerName);

        /// <summary>
        /// Get files (blobs) in container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns>Return list of string names of blobs</returns>
        public async Task<IEnumerable<string>> GetBlobs(string containerName)
        {
            await foreach (var item in GetContainerClient(containerName).GetBlobsAsync())
                files.Add(item.Name);

            return files;
        }

        /// <summary>
        /// Delete files on container
        /// </summary>
        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            var blobClient = GetContainerClient(containerName).GetBlobClient(name);
            return await blobClient.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Get file of container
        /// </summary>
        /// <param name="name">File name</param>
        /// <param name="containerName">Container name of Azure Storage</param>
        public async Task<BlobResult> GetBlob(string name, string containerName)
        {
            var blobClient = GetContainerClient(containerName).GetBlobClient(name);
            if (blobClient != null)
            {
                var blob = Task.FromResult(blobClient).Result;

                return new BlobResult
                {
                    Container = blob.BlobContainerName,
                    Name = blob.Name,
                    Url = blob.Uri.AbsoluteUri,
                };
            }
            else
                return null;
        }

        /// <summary>
        /// Upload file of Azure Storage
        /// </summary>
        /// <param name="name">File name</param>
        /// <param name="file">IFormFile content of file</param>
        /// <param name="containerName">Container name of Azure Storage</param>
        public async Task<BlobResult> UploadFileBlob(string name, IFormFile file, string containerName)
        {
            try
            {
                var blobClient = GetContainerClient(containerName).GetBlobClient(name);

                var httpHeaders = new BlobHttpHeaders
                {
                    ContentType = file.ContentType
                };

                var blobInfo = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
                if (blobInfo != null)
                {
                    return await GetBlob(name, containerName);
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public async Task<string> CreateBlobContainer(string innerContainer)
        {
            var blobContainer = new BlobServiceClient("UseDevelopmentStorage=true;");
            string containerName = string.Empty;

            var container = blobContainer.GetBlobContainerClient(innerContainer);
            if (!container.Exists())
            {
                BlobContainerClient blobContainerClient = await blobContainer.CreateBlobContainerAsync(innerContainer);
                if (await blobContainerClient.ExistsAsync())
                    containerName = blobContainerClient.Name;
            }
            else
                containerName = container?.Name;

            return containerName;
        }
    }
}
