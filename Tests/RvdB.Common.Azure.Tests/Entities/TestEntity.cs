using System;

using Azure;
using Azure.Data.Tables;

namespace RvdB.Common.Azure.Tests.Entities
{
    public class TestEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string SomeExtraProperty { get; set; }
    }
}
