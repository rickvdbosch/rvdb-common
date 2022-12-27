using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Data.Tables;

namespace RvdB.Common.Azure.Helpers
{
    public interface ITableStorageHelper
    {
        Task DeleteEntityAsync<T>(TableClient client, T entity) where T : ITableEntity;

        Task<IEnumerable<T>> GetEntitiesAsync<T>(TableClient client) where T : class, ITableEntity, new();

        Task<IEnumerable<T>> GetEntitiesByPartitionAsync<T>(TableClient client, string partitionKey) where T : class, ITableEntity, new();

        Task<T> GetEntityByPartitionKeyRowKeyAsync<T>(TableClient client, string partitionKey, string rowKey) where T : class, ITableEntity, new();

        Task InsertEntityAsync<T>(TableClient client, T entity) where T : ITableEntity;

        Task UpdateEntityAsync<T>(TableClient client, T entity) where T : ITableEntity;
    }
}