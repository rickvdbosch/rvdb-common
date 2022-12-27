using Microsoft.Extensions.DependencyInjection;

using RvdB.Common.Azure.Helpers;

namespace RvdB.Common.Azure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHelpers(this IServiceCollection serviceCollection)
        {
            Guard.IsNotNull(serviceCollection, nameof(serviceCollection));
            serviceCollection.AddTransient<ITableStorageHelper, TableStorageHelper>();

            return serviceCollection;
        }
    }
}