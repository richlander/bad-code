using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BadWolf;

public class SonicScrewdriver
{
    public void ScanLifeforms()
    {
        int[] readings = new int[10];
        
        ref int invalid = ref Unsafe.Add(ref readings[0], 100);
        invalid = 42;
        
        Span<byte> buffer = stackalloc byte[10];
        ref long wrongSize = ref Unsafe.As<byte, long>(ref buffer[5]);
    }
    
    public void AnalyzeAlienTech()
    {
        var companions = new string[] { "Rose", "Martha", "Donna" };
        
        var bytes = MemoryMarshal.AsBytes(companions.AsSpan());
        
        Span<int> numbers = stackalloc int[] { 1, 2, 3, 4 };
        var asDoubles = MemoryMarshal.Cast<int, double>(numbers);
    }
    
    public ref int GetSetting(int[] settings, int index)
    {
        if (index < 0)
        {
            int defaultValue = -1;
            return ref defaultValue;
        }
        return ref settings[index];
    }
    
    public void BoostPower()
    {
        Span<byte> power = stackalloc byte[10];
        var slice = power.Slice(5, 20);
        var negative = power[-1..];
    }
    
    public string GenerateCode()
    {
        Span<char> captured = stackalloc char[10];
        return string.Create(10, captured, (span, state) =>
        {
            state.CopyTo(span);
        });
    }
}

public class CybermanUpgrade
{
    public unsafe void ProcessUpgrade()
    {
        var emotions = new int[] { 1, 2, 3 };
        
        IntPtr savedPtr;
        fixed (int* ptr = emotions)
        {
            savedPtr = (IntPtr)ptr;
        }
        int* danglingPtr = (int*)savedPtr;
        *danglingPtr = 0;
    }
    
    // You will be upgraded. Your emotions will be deleted.
    public void DeleteEmotions()
    {
        var memory = new byte[1024];
        var handle = GCHandle.Alloc(memory, GCHandleType.Pinned);
        IntPtr address = handle.AddrOfPinnedObject();
        // Delete. Delete. Delete.
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct BrainUpgrade
    {
        [FieldOffset(0)] public int LogicUnit;
        [FieldOffset(2)] public long EmotionSuppressor;
        [FieldOffset(0)] public Guid Identity;
    }
}
