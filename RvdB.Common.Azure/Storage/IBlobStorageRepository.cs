using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RvdB.Common.Azure.Storage
{
    public interface IBlobStorageRepository
    {
        /// <summary>
        /// Adds a blob to a BlobContainer
        /// </summary>
        /// <param name="name">Name to save the blob under</param>
        /// <param name="file">Stream containing the file to save</param>
        Task AddBlobToContainerAsync(string name, Stream file);

        /// <summary>
        /// Deletes a blob from a BlobContainer
        /// </summary>
        /// <param name="name">Name of the blob to delete</param>
        Task DeleteBlobFromContainerAsync(string name);

        /// <summary>
        /// Lists all blobs in a BlobContainer
        /// </summary>
        /// <returns>A <see cref="List{string}"/> containing all blobnames in a BlobContainer</returns>
        Task<IEnumerable<string>> GetBlobNamesInContainerAsync();

        /// <summary>
        /// Lists all blobs in a BlobContainer, returning their full URLs
        /// </summary>
        /// <returns>A <see cref="List{string}"/> containing all blob URLs in a BlobContainer</returns>
        Task<IEnumerable<string>> GetBlobUrlsInContainerAsync();
    }
}