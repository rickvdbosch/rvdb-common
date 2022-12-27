# RvdB.Common.Azure

## Registering the services

```csharp
builder.Services.AddServices();
```

## RvdB.Common.Azure.Helpers.TableStorageHelper

Helper for getting all entities from a CloudTable, or getting all entities for a specific Partition Key.

### Example: GetEntitiesAsync\<T\>

```csharp

var allEntities = await TableStorageService.GetEntitiesAsync<TypedEntity>(cloudTable);
```

### Example: GetEntitiesFromPartitionAsync\<T\>

```csharp
var partitionKeyEntities = await TableStorageService.GetEntitiesByPartitionKeyAsync<TypedEntity>(cloudTable, "<PARTITION-KEY>");

```
