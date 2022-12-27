using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure;
using Azure.Data.Tables;

namespace RvdB.Common.Azure.Helpers
{
    public class TableStorageHelper : ITableStorageHelper
    {
        public async Task DeleteEntityAsync<T>(TableClient client, T entity) where T : ITableEntity
        {
            await client.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
        }

        /// <summary>
        /// Gets all entities from the provided <see cref="CloudTable"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get from <paramref name="table"/>.</typeparam>
        /// <param name="table"><see cref="CloudTable"/> to get all entities from.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities from <paramref name="table"/>.</returns>
        public async Task<IEnumerable<T>> GetEntitiesAsync<T>(TableClient client) where T : class, ITableEntity, new()
        {
            return client.Query<T>().ToList();
        }

        /// <summary>
        /// Gets all entities in the provided <paramref name="partitionKey"/> from the provided <see cref="CloudTable"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get from <paramref name="table"/>.</typeparam>
        /// <param name="table"><see cref="CloudTable"/> to get the entities from.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities from the <paramref name="partitionKey"/> partition in the <paramref name="table"/>.</returns>
        public async Task<IEnumerable<T>> GetEntitiesByPartitionAsync<T>(TableClient client, string partitionKey) where T : class, ITableEntity, new()
        {
            return client.Query<T>(e => e.PartitionKey == partitionKey).ToList();
        }

        /// <summary>
        /// Gets an entity with the provided <paramref name="partitionKey"/> and <paramref name="rowKey"/> from the provided <see cref="CloudTable"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get from <paramref name="table"/>.</typeparam>
        /// <param name="table"><see cref="CloudTable"/> to get the entity from.</param>
        /// <returns>An entity with <paramref name="partitionKey"/> and <paramref name="rowKey"/> in the <paramref name="table"/>.</returns>
        public async Task<T> GetEntityByPartitionKeyRowKeyAsync<T>(TableClient client, string partitionKey, string rowKey) where T : class, ITableEntity, new()
        {
            return (await client.GetEntityAsync<T>(partitionKey, rowKey)).Value;
        }

        public async Task InsertEntityAsync<T>(TableClient client, T entity) where T : ITableEntity
        {
            client.AddEntity(entity);
        }

        public async Task UpdateEntityAsync<T>(TableClient client, T entity) where T : ITableEntity
        {
            await client.UpdateEntityAsync(entity, ETag.All);
        }
    }
}
