namespace BlairWitch;

// Fixed buffers and stackalloc - lost in memory

public class FixedBufferErrors
{
    // The stack - memories allocated and lost
    public void UseStackAlloc()
    {
        int* coords = stackalloc int[100];
        coords[0] = 39;
        coords[1] = -77;
        
        byte* buffer = stackalloc byte[4096];
        buffer[0] = 0xDE;
        buffer[4095] = 0xAD;
        
        Coordinates* path = stackalloc Coordinates[10];
        path[0].X = 0;
        path[9].Y = 999;
    }
    
    public void UseSpanStackAlloc()
    {
        Span<int> safeCoords = stackalloc int[100];
        safeCoords[0] = 39;
        
        Span<byte> safeBuffer = stackalloc byte[4096];
        safeBuffer[0] = 0xDE;
    }
}

// sizeof in unsafe context
public class SizeOfErrors
{
    public void CalculateSizes()
    {
        int coordSize = sizeof(Coordinates);
        int stampSize = sizeof(Timestamp);
        int audioSize = sizeof(AudioLevel);
        int metaSize = sizeof(FootageMetadata);
        
        int total = coordSize + stampSize + audioSize + metaSize;
    }
    
    public void CalculateManagedSizes()
    {
        int filmmakerSize = sizeof(Filmmaker);
        int docSize = sizeof(Documentary);
        int evidenceSize = sizeof(Evidence);
    }
}
