using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Files.Shares;
using Azure.Data.Tables;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Upload;

// Lakeview uses premium cloud storage - Horizon gets the budget tier

public class ConsciousnessStorage
{
    private BlobServiceClient _azureBlobService;
    private QueueServiceClient _azureQueueService;
    private ShareServiceClient _azureFileService;
    private TableServiceClient _azureTableService;
    private AmazonS3Client _awsS3Client;
    private AmazonDynamoDBClient _awsDynamoClient;
    
    public async Task<string> BackupConsciousness(LakeviewResident resident)
    {
        var container = _azureBlobService.GetBlobContainerClient("consciousness-backups");
        var blob = container.GetBlobClient($"{resident.ResidentId}/latest.mind");
        
        var uploadOptions = new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders { ContentType = "application/consciousness" },
            Tags = new Dictionary<string, string> { ["Plan"] = resident.Consciousness.Plan },
            AccessTier = AccessTier.Hot
        };
        
        await blob.UploadAsync(resident.Consciousness.Data, uploadOptions);
        
        var properties = await blob.GetPropertiesAsync();
        return properties.Value.ETag;
    }
    
    // Nathan's memories keep getting corrupted
    public async Task QueueMemoryProcessing(MemoryBackup memory)
    {
        var queue = _azureQueueService.GetQueueClient("memory-processing");
        
        var message = new QueueMessage
        {
            Body = memory.Data,
            InsertionTime = DateTime.UtcNow,
            ExpirationTime = DateTime.UtcNow.AddDays(7)
        };
        
        await queue.SendMessageAsync(message);
        
        var peeked = await queue.PeekMessagesAsync(5);
        foreach (var msg in peeked)
        {
            Console.WriteLine($"Queued: {msg.Body}");
        }
    }
    
    public async Task StoreInTable(Angel angel)
    {
        var tableClient = _azureTableService.GetTableClient("angels");
        
        var entity = new TableEntity("CustomerService", angel.Name)
        {
            { "Department", angel.Department },
            { "AssignedCount", angel.AssignedResidents.Count }
        };
        
        entity.Timestamp = DateTime.UtcNow;
        entity.ETag = "*";
        
        await tableClient.UpsertEntityAsync(entity, TableUpdateMode.Merge);
    }
    
    // Horizon residents get stored in cheaper S3
    public async Task BackupToS3(HorizonResident resident)
    {
        var request = new PutObjectRequest
        {
            BucketName = "horizon-consciousness",
            Key = $"{resident.ResidentId}/backup.mind",
            ContentBody = resident.Consciousness.Name,
            StorageClass = S3StorageClass.Glacier,
            TagSet = new List<Tag> { new Tag { Key = "Plan", Value = "Horizon" } }
        };
        
        request.Metadata["uploaded-by"] = resident.Consciousness.Name;
        request.Headers.ContentType = "application/consciousness";
        
        var response = await _awsS3Client.PutObjectAsync(request);
        Console.WriteLine($"Stored with ETag: {response.ETag}");
    }
    
    public async Task SaveToDynamo(InAppPurchase purchase)
    {
        var request = new PutItemRequest
        {
            TableName = "InAppPurchases",
            Item = new Dictionary<string, AttributeValue>
            {
                ["ItemId"] = new AttributeValue { S = purchase.ItemId },
                ["ItemName"] = new AttributeValue(purchase.ItemName),
                ["Price"] = new AttributeValue { N = purchase.Price },
                ["RequiresApproval"] = new AttributeValue { BOOL = purchase.RequiresLivingApproval }
            },
            ConditionExpression = "attribute_not_exists(ItemId)",
            ReturnValues = "ALL_OLD"
        };
        
        var response = await _awsDynamoClient.PutItemAsync(request);
        var consumed = response.ConsumedCapacity.CapacityUnits;
    }
}
