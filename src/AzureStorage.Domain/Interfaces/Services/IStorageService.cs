using AzureStorage.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureStorage.Domain.Interfaces.Services
{
    public interface IStorageService
    {
        Task<BlobResult> GetBlob(string fileName, string containerName);
        Task<IEnumerable<string>> GetBlobs(string containerName);
        Task<BlobResult> UploadFileBlob(string fileName, IFormFile file, string containerName);
        Task<bool> DeleteBlob(string fileName, string containerName);
        Task<string> CreateBlobContainer(string genericName);
    }
}
