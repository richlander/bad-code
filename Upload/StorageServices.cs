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
        
        // ERROR: UploadBlobAsync doesn't exist - should be UploadAsync
        await blob.UploadBlobAsync(resident.Consciousness.Data);
        
        // ERROR: GetBlobProperties doesn't exist - should be GetPropertiesAsync
        var properties = await blob.GetBlobProperties();
        
        // ERROR: ContentHash doesn't exist on BlobProperties
        return properties.Value.ContentHash;
    }
    
    // Nathan's memories keep getting corrupted
    public async Task QueueMemoryProcessing(MemoryBackup memory)
    {
        var queue = _azureQueueService.GetQueueClient("memory-processing");
        
        // ERROR: SendAsync doesn't exist - should be SendMessageAsync
        await queue.SendAsync(memory.Data.ToString());
        
        // ERROR: PeekAsync doesn't exist - should be PeekMessagesAsync
        var peeked = await queue.PeekAsync(5);
        foreach (var msg in peeked.Value)
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
        
        // ERROR: InsertEntityAsync doesn't exist - should be AddEntityAsync or UpsertEntityAsync  
        await tableClient.InsertEntityAsync(entity);
        
        // ERROR: QueryEntities doesn't exist - should be QueryAsync
        var results = tableClient.QueryEntities<TableEntity>("PartitionKey eq 'CustomerService'");
    }
    
    // Horizon residents get stored in cheaper S3
    public async Task BackupToS3(HorizonResident resident)
    {
        var request = new PutObjectRequest
        {
            BucketName = "horizon-consciousness",
            Key = $"{resident.ResidentId}/backup.mind",
            ContentBody = resident.Consciousness.Name,
            // ERROR: StorageClass.Glacier doesn't exist - should be S3StorageClass.Glacier
            StorageClass = StorageClass.Glacier,
        };
        
        // ERROR: PutAsync doesn't exist - should be PutObjectAsync
        var response = await _awsS3Client.PutAsync(request);
        
        // ERROR: ObjectETag doesn't exist - should be ETag
        Console.WriteLine($"Stored with ETag: {response.ObjectETag}");
    }
    
    public async Task SaveToDynamo(InAppPurchase purchase)
    {
        var request = new PutItemRequest
        {
            TableName = "InAppPurchases",
            Item = new Dictionary<string, AttributeValue>
            {
                ["ItemId"] = new AttributeValue { S = purchase.ItemId },
                ["Price"] = new AttributeValue { N = purchase.Price },
            },
        };
        
        // ERROR: PutAsync doesn't exist - should be PutItemAsync
        var response = await _awsDynamoClient.PutAsync(request);
        
        // ERROR: ConsumedUnits doesn't exist
        var consumed = response.ConsumedUnits;
    }
    
    public async Task ListAllBuckets()
    {
        // ERROR: ListBucketsAsync doesn't exist on S3 - need ListBucketsAsync
        var buckets = await _awsS3Client.GetBuckets();
        
        foreach (var bucket in buckets.Buckets)
        {
            // ERROR: BucketName doesn't exist - should be Name (on S3Bucket)
            Console.WriteLine(bucket.BucketName);
        }
    }
}
