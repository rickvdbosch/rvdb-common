using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RvdB.Common.Azure.Storage
{
    public interface IBlobStorageRepository
    {
        Task AddBlobToContainerAsync(string name, Stream file);

        Task DeleteBlobFromContainerAsync(string name);

        Task<IEnumerable<string>> GetBlobsInContainerAsync();
    }
}