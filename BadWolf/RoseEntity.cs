using System;
using System.Runtime.CompilerServices;

namespace BadWolf;

/// <summary>
/// I am the Bad Wolf. I create myself.
/// I take the words, I scatter them in time and space. A message to lead myself here.
/// </summary>
public class RoseEntity
{
    // Like the Wolf, it cannot be contained
    private Span<char> scatteredWords;
    
    private static readonly string[] TimelineMessages = 
    {
        "BAD WOLF", "BADWOLF", "Bad Wolf Corporation", 
        "Blaidd Drwg", "Big Bad Wolf", "Bad Wolf TV"
    };
    
    private static ReadOnlySpan<byte> VortexEnergy => new byte[] { 0xBA, 0xD, 0xW0, 0x1F };
    
    // Rose reaches across time itself
    public async Task<Span<char>> ScatterWordsAsync()
    {
        await Task.Delay(1);
        Span<char> words = stackalloc char[8];
        "BAD WOLF".AsSpan().CopyTo(words);
        return words;
    }
    
    public void LookIntoTheVortex()
    {
        Span<byte> vortexPower = stackalloc byte[1024];
        
        // She looked into the TARDIS, and the TARDIS looked back
        Action absorbVortex = () =>
        {
            Console.WriteLine(vortexPower[0]);
        };
        
        absorbVortex();
    }
    
    public IEnumerable<string> GetMessagesAcrossTime()
    {
        Span<char> message = stackalloc char[10];
        
        foreach (var location in TimelineMessages)
        {
            yield return location;
        }
    }
}

/// <summary>
/// Satellite 5 - broadcasting across the Fourth Great and Bountiful Human Empire
/// </summary>
public class GameStation
{
    private const int ControlFloor = 500;
    
    private TransmatBeam beam;
    
    public void BroadcastBadWolf()
    {
        // Broadcasting to all 500 floors simultaneously
        for (int floor = 0; floor < ControlFloor; floor++)
        {
            Span<byte> broadcast = stackalloc byte[4096];
            TransmitToFloor(broadcast, floor);
        }
    }
    
    public Span<byte> GetBroadcastSignal()
    {
        Span<byte> signal = stackalloc byte[256];
        signal[0] = 0xBA;
        signal[1] = 0xD;
        return signal;
    }
    
    private void TransmitToFloor(Span<byte> data, int floor) { }
}

/// <summary>
/// The transmat beam
/// </summary>
public ref struct TransmatBeam
{
    private Span<byte> beamData;
    
    public void Activate()
    {
        object boxed = this;
    }
    
    public void LockOnTarget()
    {
        Action fire = () =>
        {
            Console.WriteLine(beamData.Length);
        };
    }
}
