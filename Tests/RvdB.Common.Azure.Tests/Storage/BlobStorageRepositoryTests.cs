using System.Threading.Tasks;

using RvdB.Common.Azure.Storage;

using Xunit;

namespace RvdB.Common.Azure.Tests
{
    public class BlobStorageRepositoryTests
    {
        #region Constants

        private const string CONNECTIONSTRING = "UseDevelopmentStorage=true";
        private const string CONTAINERNAME = "output";

        #endregion

        [Fact]
        public async Task GetBlobsInContainerAsync_ShouldReturnBlobs()
        {
            var blobStorageRepository = new BlobStorageRepository(CONNECTIONSTRING, CONTAINERNAME);
            var blobs = await blobStorageRepository.GetBlobsInContainerAsync();

            Assert.NotNull(blobs);
            Assert.NotEmpty(blobs);
        }
    }
}
