using System;
using System.IO;
using System.Threading.Tasks;
using BlandGroupApi.Interfaces;
using BlandGroupShared.EntityFramework;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlandGroupApi.Services
{
    public class FileService : IFileService
    {
        private readonly CloudBlobClient _blobClient;
        private readonly ApplicationDbContext _dbContext;

        public FileService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            var storageAccount = CloudStorageAccount.Parse(configuration.GetConnectionString("AzureStorage"));
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<UserFile> ProcessFileAsync(Stream fileStream, string fileName, string contentType, string extension)
        {
            try
            {
                var container = _blobClient.GetContainerReference("userFiles");
                await container.CreateIfNotExistsAsync();

                var blobName = $"{Guid.NewGuid()}{extension}";
                var blockBlob = container.GetBlockBlobReference(blobName);

                await blockBlob.UploadFromStreamAsync(fileStream);

                var file = new UserFile
                {
                    Name = fileName,
                    Size = fileStream.Length,
                    ContentType = contentType,
                    Extension = extension,
                    TimestampProcessed = DateTime.UtcNow,
                    FilePath = blockBlob.Uri.ToString()
                };

                _dbContext.UserFiles.Add(file);

                await _dbContext.SaveChangesAsync();

                return file;
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new ApplicationException("Error processing the file.", ex);
            }
        }
    }
}


