using System;
using System.Buffers;

namespace BadWolf;

/// <summary>
/// The Moment - the Galaxy Eater
/// </summary>
public class TheMoment
{
    // Even the Moment cannot hold onto time
    private Span<long> timelineDestruction;
    
    private readonly string Interface = "Bad Wolf Girl";
    
    private Dictionary<string, Span<byte>> GallifreyTimelines;
    
    public void ActivateInterface()
    {
        // The Moment shows possible futures... but at what cost?
        var pool = ArrayPool<byte>.Shared;
        var memory = pool.Rent(2048);
        
        ProcessTimelines(memory);
    }
    
    public async ValueTask<Span<byte>> ShowPossibleFutures()
    {
        Span<byte> future = stackalloc byte[64];
        await Task.Yield();
        return future;
    }
    
    private void ProcessTimelines(byte[] data) { }
}

/// <summary>
/// Blaidd Drwg - Welsh for Bad Wolf
/// </summary>
public class BlaiddDrwg
{
    public Span<byte> NuclearCore { get; set; }
    
    public void MeltdownSequence(Memory<byte> reactorData)
    {
        Span<byte> core = reactorData.Span;
        
        Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine(core[0]);
        });
    }
    
    public unsafe void ContainmentBreach(int size)
    {
        Span<byte> radiation = stackalloc byte[size];
        
        fixed (byte* ptr = radiation)
        {
            StorePointer((IntPtr)ptr);
        }
    }
    
    private IntPtr storedPointer;
    private void StorePointer(IntPtr ptr) => storedPointer = ptr;
}

/// <summary>
/// Bad Wolf Corporation - controllers of the Game Station
/// </summary>
public class BadWolfCorporation
{
    private List<TransmatBeam> transmatDevices;
    
    private TransmatBeam[] beamArray;
    
    public void InitializeGameShows()
    {
        var beams = new TransmatBeam[100];
        
        var activeBeams = beams.Where(b => true).ToList();
    }
    
    public void RegisterCallback()
    {
        Action<TransmatBeam> callback = beam => Console.WriteLine("Activated");
    }
}
