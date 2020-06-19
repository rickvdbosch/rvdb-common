using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos.Table;

namespace RvdB.Common.Azure.Storage
{
    public interface ITableStorageRepository
    {
        /// <summary>
        /// Deletes an entity from Table Storage
        /// </summary>
        /// <typeparam name="T">The type of entity to delete</typeparam>
        /// <param name="entity">The entity to delete</param>
        Task DeleteEntityAsync<T>(T entity) where T : ITableEntity;

        /// <summary>
        /// Gets all entities from a Table Storage table
        /// </summary>
        /// <typeparam name="T">The type of entities to get</typeparam>
        /// <returns>An IEnumerable of <typeparamref name="T"/> for all entities</returns>
        Task<IEnumerable<T>> GetAllEntitiesAsync<T>() where T : ITableEntity, new();

        /// <summary>
        /// Gets all entities from a specific partition from a Table Storage table
        /// </summary>
        /// <typeparam name="T">The type of entities to get</typeparam>
        /// <param name="partitionKey">PartitionKey to get all entities from</param>
        /// <returns>An IEnumerable of <typeparamref name="T"/> for the specified <paramref name="partitionKey"/></returns>
        Task<IEnumerable<T>> GetEntitiesByPartitionKeyAsync<T>(string partitionKey) where T : ITableEntity, new();

        /// <summary>
        /// Gets a specific entity from a Table Storage table
        /// </summary>
        /// <typeparam name="T">The type of entity to get</typeparam>
        /// <param name="partitionKey">PartitionKey of the entity to get</param>
        /// <param name="rowKey">RowKey of the entity to get</param>
        /// <returns>An instance of <typeparamref name="T"/> for the specified <paramref name="partitionKey"/> and <paramref name="rowKey"/></returns>
        Task<T> GetEntityByPartitionKeyRowKeyAsync<T>(string partitionKey, string rowKey) where T : ITableEntity, new();

        /// <summary>
        /// Inserts an entity into the Table Storage table
        /// </summary>
        /// <typeparam name="T">The type of entity to insert</typeparam>
        /// <param name="entity">The entity to insert</param>
        Task InsertEntityAsync<T>(T entity) where T : ITableEntity;

        /// <summary>
        /// Updates an entity in the Table Storage table
        /// </summary>
        /// <typeparam name="T">The type of entity to update</typeparam>
        /// <param name="entity">The entity to update</param>
        Task UpdateEntityAsync<T>(T entity) where T : ITableEntity;
    }
}