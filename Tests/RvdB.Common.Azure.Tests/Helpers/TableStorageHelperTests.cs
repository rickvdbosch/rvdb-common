using System;
using System.Threading.Tasks;

using Azure.Data.Tables;

using RvdB.Common.Azure.Helpers;
using RvdB.Common.Azure.Tests.Entities;

using Xunit;

namespace RvdB.Common.Azure.Tests.Helpers
{
    public class TableStorageHelperTests
    {
        private const string STORAGE_CONNECTIONSTRING = "UseDevelopmentStorage=true";

        private TableClient _tableClientTestEntities;
        private ITableStorageHelper _tableStorageHelper = new TableStorageHelper();

        private readonly TestEntity _testEntityOne = new() { PartitionKey = "pk-one", RowKey = "rk-three", SomeExtraProperty = "extra-three" };
        private readonly TestEntity _testEntityUnknown = new() { PartitionKey = "pk-unknown", RowKey = "rk-unknown", SomeExtraProperty = "extra-unknown" };

        public TableStorageHelperTests()
        {
            var tableServiceClient = new TableServiceClient(STORAGE_CONNECTIONSTRING);
            _tableClientTestEntities = tableServiceClient.GetTableClient("TestEntities");
        }

        [Fact]
        public async Task DeleteEntity_WhenNotPresent_Does()
        {
            await _tableStorageHelper.DeleteEntityAsync(_tableClientTestEntities, _testEntityUnknown);
        }
    }
}
