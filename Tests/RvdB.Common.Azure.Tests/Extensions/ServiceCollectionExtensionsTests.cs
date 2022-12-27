using System;

using Microsoft.Extensions.DependencyInjection;

using RvdB.Common.Azure.Extensions;
using RvdB.Common.Azure.Helpers;

using Xunit;

namespace RvdB.Common.Azure.Tests.Extensions
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddHelpers_OnNull_ThrowsArgumentNullException()
        {
            // Arrange
            IServiceCollection collection = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => collection.AddHelpers());
        }

        [Fact]
        public void AddHelpers_OnServiceCollection_AddsTableStorageRepository()
        {
            // Arrange
            var collection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            // Act
            collection.AddHelpers();

            // Assert
            Assert.NotEmpty(collection);
            Assert.Contains(collection, x => x.ImplementationType == typeof(TableStorageHelper));
        }
    }
}
