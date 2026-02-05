using Azure.Storage.Blobs.Models;
using Azure.Messaging.ServiceBus;
using Amazon.S3.Model;
using Amazon.DynamoDBv2.Model;

namespace Upload;

// Span-based consciousness processing - high performance afterlife

public class SpanProcessor
{
    // Spans as fields - not allowed
    private Span<byte> _consciousnessBuffer;
    private Span<BlobItem> _blobSpan;
    private Span<S3Object> _s3Span;
    private ReadOnlySpan<char> _messageSpan;
    
    // Span properties - not allowed
    public Span<byte> ConsciousnessData { get; set; }
    public Span<AttributeValue> DynamoValues { get; set; }
    public ReadOnlySpan<ServiceBusMessage> Messages { get; set; }
    
    // Async methods with Span - not allowed
    public async Task ProcessConsciousnessAsync(Span<byte> data)
    {
        await Task.Delay(100);
        data[0] = 0xFF;
    }
    
    public async Task<int> AnalyzeS3ObjectsAsync(Span<S3Object> objects)
    {
        await Task.Delay(50);
        return objects.Length;
    }
    
    public async Task ProcessBlobsAsync(ReadOnlySpan<BlobItem> blobs)
    {
        foreach (var blob in blobs)
        {
            await Task.Delay(10);
            Console.WriteLine(blob.Name);
        }
    }
    
    public async ValueTask<Span<byte>> GetConsciousnessAsync()
    {
        await Task.Delay(100);
        return new byte[1024];
    }
    
    // Iterator with Span - not allowed
    public IEnumerable<byte> EnumerateConsciousness(Span<byte> data)
    {
        foreach (var b in data)
        {
            yield return b;
        }
    }
    
    public IEnumerable<S3Object> EnumerateObjects(Span<S3Object> objects)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            yield return objects[i];
        }
    }
    
    // Lambda capturing Span - not allowed
    public void ProcessWithLambda()
    {
        Span<byte> data = stackalloc byte[1024];
        
        Action process = () =>
        {
            data[0] = 0x00;
            Console.WriteLine(data.Length);
        };
        
        Func<int> getLength = () => data.Length;
        
        var processor = new Action<int>(i => data[i] = (byte)i);
    }
    
    // Span as generic type argument - not allowed
    public void GenericSpanErrors()
    {
        var list = new List<Span<byte>>();
        var dict = new Dictionary<string, Span<S3Object>>();
        var queue = new Queue<ReadOnlySpan<char>>();
        
        Task<Span<byte>> task = null;
        Lazy<Span<BlobItem>> lazy = null;
    }
    
    // Boxing Span - not allowed
    public void BoxingErrors()
    {
        Span<byte> data = stackalloc byte[100];
        object boxed = data;
        
        ReadOnlySpan<char> text = "consciousness";
        IComparable comparable = (IComparable)(object)text;
    }
    
    // Span in class that stores it
    public class ConsciousnessHolder
    {
        public Span<byte> Data;
        public ReadOnlySpan<char> Name;
        private Span<S3Object> _objects;
        
        public ConsciousnessHolder(Span<byte> data)
        {
            Data = data;
        }
    }
    
    // Return stackalloc - escaping stack memory
    public Span<byte> GetStackData()
    {
        Span<byte> data = stackalloc byte[1024];
        data[0] = 0xFF;
        return data;
    }
    
    public ReadOnlySpan<int> GetStackInts()
    {
        Span<int> ints = stackalloc int[256];
        return ints;
    }
    
    // Span with array from SDK types
    public void ProcessSdkArrays()
    {
        var s3Response = new ListObjectsV2Response();
        Span<S3Object> objectSpan = s3Response.S3Objects.ToArray();
        _s3Span = objectSpan;
        
        var blobPage = new List<BlobItem>();
        Span<BlobItem> blobSpan = blobPage.ToArray();
        _blobSpan = blobSpan;
    }
    
    // Async local function with Span
    public void AsyncLocalWithSpan()
    {
        Span<byte> data = stackalloc byte[100];
        
        async Task ProcessAsync()
        {
            await Task.Delay(10);
            Console.WriteLine(data.Length);
        }
        
        ProcessAsync().Wait();
    }
    
    // LINQ with Span - can't use LINQ on Span
    public void LinqOnSpan()
    {
        Span<byte> data = stackalloc byte[100];
        
        var filtered = data.Where(b => b > 0);
        var selected = data.Select(b => (int)b);
        var first = data.First();
        var count = data.Count();
    }
}

// Ref struct used incorrectly
public ref struct ConsciousnessSlice
{
    public Span<byte> Data;
    public ReadOnlySpan<char> Metadata;
    
    // Can't implement interfaces
    // public void Dispose() { }
}

public class RefStructErrors
{
    // Ref struct as field - not allowed
    private ConsciousnessSlice _slice;
    
    // Ref struct as type argument - not allowed
    public List<ConsciousnessSlice> Slices { get; set; }
    
    // Ref struct in async - not allowed
    public async Task ProcessSliceAsync(ConsciousnessSlice slice)
    {
        await Task.Delay(100);
    }
    
    // Boxing ref struct - not allowed
    public void BoxRefStruct()
    {
        var slice = new ConsciousnessSlice();
        object boxed = slice;
    }
    
    // Ref struct in iterator - not allowed
    public IEnumerable<int> IterateSlice(ConsciousnessSlice slice)
    {
        for (int i = 0; i < slice.Data.Length; i++)
        {
            yield return slice.Data[i];
        }
    }
}
