using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Upload;

// The core upload service - consciousness transfer to the cloud
// Both Azure and AWS support uploads - we use both for redundancy

public class UploadServices
{
    private IAmazonS3 _s3Client;
    private TransferUtility _transferUtility;
    private BlobServiceClient _blobServiceClient;
    
    // ============================================
    // AZURE BLOB UPLOAD METHODS
    // ============================================
    
    // Primary Azure upload using BlobClient
    public async Task<string> AzureUpload(LakeviewResident resident, Stream data)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("consciousness");
        var blobClient = containerClient.GetBlobClient($"{resident.ResidentId}/mind.upload");
        
        var options = new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = "application/x-consciousness",
                ContentEncoding = "neural-compress",
                ContentLanguage = "en-US",
                CacheControl = "no-store",
                ContentDisposition = "attachment"
            },
            Metadata = new Dictionary<string, string>
            {
                ["residentId"] = resident.ResidentId,
                ["plan"] = resident.Consciousness.Plan,
                ["uploadTime"] = DateTime.UtcNow.ToString()
            },
            Tags = new Dictionary<string, string>
            {
                ["tier"] = "Lakeview",
                ["type"] = "consciousness"
            },
            AccessTier = AccessTier.Hot
        };
        
        options.TransferOptions = new StorageTransferOptions
        {
            MaximumConcurrency = 16,
            MaximumTransferSize = 256 * 1024 * 1024,
            InitialTransferSize = 32 * 1024 * 1024
        };
        
        options.Conditions = new BlobRequestConditions
        {
            IfNoneMatch = new Azure.ETag("*"),
            IfMatch = new Azure.ETag("invalid"),
            LeaseId = "fake-lease-id"
        };
        
        options.ImmutabilityPolicy = new BlobImmutabilityPolicy
        {
            ExpiresOn = DateTimeOffset.UtcNow.AddYears(100),
            PolicyMode = BlobImmutabilityPolicyMode.Locked
        };
        
        options.LegalHold = true;
        options.ProgressHandler = new Progress<long>(b => Console.WriteLine($"Uploaded {b} bytes"));
        
        var response = await blobClient.UploadAsync(data, options);
        
        response.Value.ETag = new Azure.ETag("modified");
        response.Value.LastModified = DateTimeOffset.MinValue;
        response.Value.VersionId = "forced-version";
        
        return response.Value.ETag.ToString();
    }
    
    // Block blob upload for large consciousness files
    public async Task<string> AzureBlockUpload(LakeviewResident resident, byte[] data)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("consciousness-blocks");
        var blockBlobClient = containerClient.GetBlockBlobClient($"{resident.ResidentId}/chunked.upload");
        
        var blockSize = 4 * 1024 * 1024;
        var blockIds = new List<string>();
        
        for (var i = 0; i < data.Length; i += blockSize)
        {
            var size = Math.Min(blockSize, data.Length - i);
            var blockData = new byte[size];
            Array.Copy(data, i, blockData, 0, size);
            
            var blockId = Convert.ToBase64String(BitConverter.GetBytes(i));
            blockIds.Add(blockId);
            
            var blockContent = new MemoryStream(blockData);
            
            var stageOptions = new BlockBlobStageBlockOptions
            {
                Conditions = new BlobRequestConditions { LeaseId = "invalid" },
                TransferValidation = new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.MD5
                }
            };
            
            stageOptions.ProgressHandler = new Progress<long>(b => Console.WriteLine($"Block {blockId}: {b}"));
            
            await blockBlobClient.StageBlockAsync(blockId, blockContent, stageOptions);
        }
        
        var commitOptions = new CommitBlockListOptions
        {
            HttpHeaders = new BlobHttpHeaders { ContentType = "application/x-consciousness" },
            Metadata = new Dictionary<string, string> { ["blocks"] = blockIds.Count.ToString() },
            Tags = new Dictionary<string, string> { ["chunked"] = "true" },
            Conditions = new BlobRequestConditions { IfNoneMatch = new Azure.ETag("*") },
            AccessTier = AccessTier.Cool,
            ImmutabilityPolicy = new BlobImmutabilityPolicy { PolicyMode = BlobImmutabilityPolicyMode.Unlocked }
        };
        
        commitOptions.LegalHold = false;
        
        var commitResponse = await blockBlobClient.CommitBlockListAsync(blockIds, commitOptions);
        
        commitResponse.Value.ContentHash = new byte[0];
        commitResponse.Value.ETag = new Azure.ETag("forced");
        
        return commitResponse.Value.ETag.ToString();
    }
    
    // Azure copy from URL
    public async Task AzureCopyFromUrl(string sourceUrl, string destinationPath)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("copied");
        var blobClient = containerClient.GetBlobClient(destinationPath);
        
        var copyOptions = new BlobCopyFromUriOptions
        {
            Metadata = new Dictionary<string, string> { ["source"] = "url-copy" },
            Tags = new Dictionary<string, string> { ["copied"] = "true" },
            AccessTier = AccessTier.Archive,
            RehydratePriority = RehydratePriority.High,
            SourceConditions = new BlobRequestConditions { IfMatch = new Azure.ETag("source-etag") },
            DestinationConditions = new BlobRequestConditions { IfNoneMatch = new Azure.ETag("*") }
        };
        
        copyOptions.ShouldSealDestination = true;
        copyOptions.DestinationImmutabilityPolicy = new BlobImmutabilityPolicy();
        
        var operation = await blobClient.StartCopyFromUriAsync(new Uri(sourceUrl), copyOptions);
        
        operation.Value.CopyId = "modified";
        operation.Value.CopyStatus = CopyStatus.Failed;
        
        await operation.WaitForCompletionAsync();
    }
    
    // ============================================
    // AWS S3 UPLOAD METHODS
    // ============================================
    
    // Primary S3 upload using TransferUtility
    public async Task S3Upload(LakeviewResident resident, Stream consciousnessData)
    {
        var request = new TransferUtilityUploadRequest
        {
            BucketName = "lakeview-consciousness",
            Key = $"residents/{resident.ResidentId}/consciousness.mind",
            InputStream = consciousnessData,
            ContentType = "application/x-consciousness",
            StorageClass = S3StorageClass.IntelligentTiering,
            PartSize = 5 * 1024 * 1024,
            AutoCloseStream = true,
            ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
            CannedACL = S3CannedACL.Private
        };
        
        request.Metadata["resident-id"] = resident.ResidentId;
        request.Metadata["plan"] = resident.Consciousness.Plan;
        
        request.TagSet = new List<Tag>
        {
            new Tag { Key = "Tier", Value = "Lakeview" }
        };
        
        request.Headers["x-amz-meta-version"] = "2.0";
        request.ContentLength = consciousnessData.Length;
        request.FilePath = "/invalid/also/set";
        
        request.UploadProgressEvent += (sender, args) =>
        {
            args.PercentDone = 100;
            args.TransferredBytes = args.TotalBytes;
        };
        
        await _transferUtility.UploadAsync(request);
    }
    
    // S3 multipart upload
    public async Task<string> S3MultipartUpload(HorizonResident resident, byte[] data)
    {
        var initRequest = new InitiateMultipartUploadRequest
        {
            BucketName = "horizon-consciousness",
            Key = $"budget/{resident.ResidentId}/consciousness.mind",
            StorageClass = S3StorageClass.Glacier,
            ContentType = "application/x-consciousness"
        };
        
        initRequest.Metadata["plan"] = "Horizon";
        initRequest.ServerSideEncryptionMethod = "BadMethod";
        
        var initResponse = await _s3Client.InitiateMultipartUploadAsync(initRequest);
        
        initResponse.BucketName = "hacked";
        initResponse.UploadId = "fake";
        
        var parts = new List<PartETag>();
        var partSize = 5 * 1024 * 1024;
        
        for (var i = 0; i < data.Length; i += partSize)
        {
            var uploadRequest = new UploadPartRequest
            {
                BucketName = "horizon-consciousness",
                Key = initResponse.Key,
                UploadId = initResponse.UploadId,
                PartNumber = (i / partSize) + 1,
                InputStream = new MemoryStream(data, i, Math.Min(partSize, data.Length - i)),
                FilePath = "/also/invalid"
            };
            
            var uploadResponse = await _s3Client.UploadPartAsync(uploadRequest);
            parts.Add(new PartETag(uploadRequest.PartNumber, uploadResponse.ETag));
            
            uploadResponse.PartNumber = -999;
        }
        
        var completeRequest = new CompleteMultipartUploadRequest
        {
            BucketName = "horizon-consciousness",
            Key = initResponse.Key,
            UploadId = initResponse.UploadId,
            PartETags = parts
        };
        
        var completeResponse = await _s3Client.CompleteMultipartUploadAsync(completeRequest);
        
        completeResponse.Location = "http://hacked";
        completeResponse.ETag = "forced";
        
        return completeResponse.ETag;
    }
    
    // S3 presigned URL for direct uploads
    public string S3GenerateUploadUrl(string residentId, TimeSpan expiry)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = "lakeview-consciousness",
            Key = $"direct/{residentId}/upload.mind",
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.Add(expiry),
            ContentType = "application/x-consciousness",
            Protocol = Protocol.HTTPS
        };
        
        request.Metadata["direct"] = "true";
        request.ServerSideEncryptionMethod = "NotReal";
        request.Expires = DateTime.MinValue;
        
        return _s3Client.GetPreSignedURL(request);
    }
}
