using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace RvdB.Common.Azure.Storage
{
    public class BlobStorageRepository : IBlobStorageRepository
    {
        #region Fields

        private readonly BlobContainerClient _blobContainerClient;

        #endregion

        #region Constructors

        public BlobStorageRepository(string connectionString, string containerName)
        {
            _blobContainerClient = new BlobContainerClient(connectionString, containerName);
        }

        #endregion

        public async Task<IEnumerable<string>> GetBlobNamesInContainerAsync()
        {
            string continuationToken = null;
            var files = new List<BlobItem>();

            do
            {
                var resultSegment = _blobContainerClient.GetBlobsAsync().AsPages(continuationToken);

                await foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    files.AddRange(blobPage.Values);
                    continuationToken = blobPage.ContinuationToken;
                }

            } while (!string.IsNullOrEmpty(continuationToken));

            return files.Select(f => f.Name);
        }

        public async Task<IEnumerable<string>> GetBlobUrlsInContainerAsync()
        {
            string continuationToken = null;
            var files = new List<BlobItem>();

            do
            {
                var resultSegment = _blobContainerClient.GetBlobsAsync().AsPages(continuationToken);

                await foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    files.AddRange(blobPage.Values);
                    continuationToken = blobPage.ContinuationToken;
                }

            } while (!string.IsNullOrEmpty(continuationToken));

            return files.Select(f => $"{_blobContainerClient.Uri}/{f.Name}");
        }

        public async Task DeleteBlobFromContainerAsync(string name)
        {
            await _blobContainerClient.DeleteBlobAsync(name);
        }

        public async Task AddBlobToContainerAsync(string name, Stream file)
        {
            await _blobContainerClient.UploadBlobAsync(name, file);
        }
    }
}