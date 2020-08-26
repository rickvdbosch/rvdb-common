using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos.Table;

namespace RvdB.Common.Azure.Helpers
{
    public static class TableStorageHelper
    {
        /// <summary>
        /// Gets all entities from the provided <see cref="CloudTable"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get from <paramref name="table"/>.</typeparam>
        /// <param name="table"><see cref="CloudTable"/> to get all entities from.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities from <paramref name="table"/>.</returns>
        public static async Task<IEnumerable<T>> GetEntitiesAsync<T>(CloudTable table) where T : ITableEntity, new()
        {
            var entities = new List<T>();
            var query = new TableQuery<T>();
            TableQuerySegment<T> querySegment = null;

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }

        /// <summary>
        /// Gets all entities in the provided <paramref name="partitionKey"/> from the provided <see cref="CloudTable"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get from <paramref name="table"/>.</typeparam>
        /// <param name="table"><see cref="CloudTable"/> to get the entities from.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities from the <paramref name="partitionKey"/> partition in the <paramref name="table"/>.</returns>
        public static async Task<IEnumerable<T>> GetEntitiesFromPartitionAsync<T>(CloudTable table, string partitionKey) where T : ITableEntity, new()
        {
            var entities = new List<T>();
            TableQuerySegment<T> querySegment = null;
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition(nameof(ITableEntity.PartitionKey), QueryComparisons.Equal, partitionKey));

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }
    }
}
