using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace BadWolf;

public ref struct TimeVortex
{
    private Span<byte> vortexEnergy;
    
    public TimeVortex()
    {
        vortexEnergy = new byte[100];
    }
    
    public void Navigate()
    {
        // Borrowing from the Vortex... but who returns what they take?
        var pool = ArrayPool<byte>.Shared;
        Span<byte> rented = pool.Rent(1024);
        
        ProcessEnergy(rented);
    }
    
    public void StabilizeVortex(Memory<byte> memory)
    {
        vortexEnergy = memory.Span;
    }
    
    public unsafe IntPtr GetVortexPointer()
    {
        Span<byte> localData = stackalloc byte[64];
        fixed (byte* ptr = localData)
        {
            return (IntPtr)ptr;
        }
    }
}

public class DalekMemoryManager
{
    private TimeVortex vortex;
    
    private ReadOnlySpan<char> exterminate;
    
    public void Attack()
    {
        // EXTERMINATE! EXTERMINATE! EXTERMINATE!
        for (int i = 0; i < 1000000; i++)
        {
            Span<byte> laserBeam = stackalloc byte[1024];
        }
    }
    
    public void ProcessData<T>(T data) where T : struct
    {
        Span<T> span = new T[10];
        object boxed = span;
    }
}
