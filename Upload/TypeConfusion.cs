using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.EventHubs;
using Azure.Security.KeyVault.Secrets;
using Azure.Security.KeyVault.Keys;
using Azure.AI.TextAnalytics;
using Azure.Monitor.Query;
using Microsoft.Azure.Cosmos;
using Azure.Search.Documents;
using Azure.ResourceManager;
using Azure.Communication.Email;
using Azure.DigitalTwins.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.Bedrock;
using Amazon.Rekognition;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.SimpleEmail;

namespace Upload;

// Type confusion across 60 packages - the afterlife has compatibility issues

public class TypeConfusion
{
    // Azure types assigned to AWS variables and vice versa
    public void CrossCloudTypeErrors()
    {
        BlobClient azureBlob = new AmazonS3Client();
        
        AmazonS3Client awsS3 = new BlobServiceClient("connection");
        
        ServiceBusMessage sbMessage = new Amazon.SQS.Model.Message();
        
        Amazon.SQS.Model.SendMessageRequest sqsRequest = new ServiceBusMessage("hello");
        
        KeyVaultSecret kvSecret = new GetSecretValueResponse();
        
        GetSecretValueResponse awsSecret = new KeyVaultSecret("name", "value");
        
        DocumentSentiment sentiment = new Amazon.Comprehend.Model.DetectSentimentResponse();
        
        Container cosmosContainer = new Amazon.DynamoDBv2.Model.TableDescription();
    }
    
    // Wrong return types
    public BlobClient GetStorage()
    {
        return new AmazonS3Client();
    }
    
    public AmazonS3Client GetS3()
    {
        return new BlobServiceClient("conn");
    }
    
    public ServiceBusMessage GetMessage()
    {
        return new Amazon.SQS.Model.Message();
    }
    
    public KeyVaultSecret GetSecret()
    {
        return new GetSecretValueResponse();
    }
    
    // Wrong parameter types
    public async System.Threading.Tasks.Task ProcessBlob(AmazonS3Client blob)
    {
        var properties = await blob.GetPropertiesAsync();
    }
    
    public async System.Threading.Tasks.Task ProcessS3(BlobClient s3)
    {
        var obj = await s3.GetObjectAsync("bucket", "key");
    }
    
    public void SendMessage(Amazon.SQS.Model.Message serviceBusMsg)
    {
        var body = serviceBusMsg.Body;
        var to = serviceBusMsg.To;
    }
    
    public void ProcessSqsMessage(ServiceBusMessage sqsMsg)
    {
        var receiptHandle = sqsMsg.ReceiptHandle;
        var attributes = sqsMsg.Attributes;
    }
    
    // Collection type mismatches
    public void CollectionErrors()
    {
        List<BlobItem> blobs = new List<S3Object>();
        
        List<S3Object> s3Objects = new List<BlobItem>();
        
        Dictionary<string, AttributeValue> cosmosItem = new Dictionary<string, Azure.Data.Tables.TableEntity>();
        
        IEnumerable<QueueMessage> queueMessages = new List<Amazon.SQS.Model.Message>();
    }
    
    // Generic type argument errors
    public void GenericErrors()
    {
        var azureResponse = new Azure.Response<AmazonS3Client>();
        
        var awsResponse = new Amazon.Runtime.AmazonWebServiceResponse<BlobClient>();
        
        var asyncEnum = new Azure.AsyncPageable<S3Object>();
        
        IProgress<GetObjectResponse> progress = new Progress<BlobDownloadInfo>();
    }
    
    // Mixing Azure and AWS request/response types
    public async System.Threading.Tasks.Task RequestResponseMismatch()
    {
        var s3Client = new AmazonS3Client();
        var blobRequest = new BlobUploadOptions();
        await s3Client.PutObjectAsync(blobRequest);
        
        var blobClient = new BlobClient("conn", "container", "blob");
        var s3Request = new PutObjectRequest();
        await blobClient.UploadAsync(s3Request);
        
        var sqsClient = new AmazonSQSClient();
        var sbMessage = new ServiceBusMessage("test");
        await sqsClient.SendMessageAsync(sbMessage);
        
        var lambdaClient = new AmazonLambdaClient();
        var azureFunction = new Azure.ResourceManager.Resources.ResourceGroupResource();
        await lambdaClient.InvokeAsync(azureFunction);
    }
    
    // Event/callback type mismatches
    public void EventMismatch()
    {
        var s3Request = new Amazon.S3.Transfer.TransferUtilityUploadRequest();
        s3Request.UploadProgressEvent += (sender, args) =>
        {
            BlobUploadOptions options = args;
            var tier = args.AccessTier;
        };
        
        var blobOptions = new BlobUploadOptions();
        blobOptions.ProgressHandler = new Progress<PutObjectResponse>(response =>
        {
            Console.WriteLine(response.ETag);
        });
    }
    
    // Credential type confusion
    public void CredentialErrors()
    {
        var azureIdentity = new Azure.Identity.DefaultAzureCredential();
        var s3Client = new AmazonS3Client(azureIdentity);
        
        var awsCreds = new Amazon.Runtime.BasicAWSCredentials("key", "secret");
        var blobService = new BlobServiceClient("conn", awsCreds);
        
        var kvClient = new SecretClient(new Uri("https://vault"), awsCreds);
        
        var dynamoClient = new AmazonDynamoDBClient(azureIdentity);
    }
}
