using System;
using System.Buffers;

namespace BadWolf;

public class Tardis
{
    // Bigger on the inside, but some things still don't fit
    private Span<byte> chameleonCircuit;
    
    // Time can be rewritten, but not like this
    private List<Span<int>> dimensionalCoordinates;
    
    public Span<char> TranslationMatrix { get; set; }
    
    public Tardis()
    {
        chameleonCircuit = stackalloc byte[100];
    }
    
    public async Task<Span<byte>> GetCoordinatesAsync()
    {
        await Task.Delay(100);
        Span<byte> coords = stackalloc byte[8];
        return coords;
    }
    
    public IEnumerable<int> GetTimelineData()
    {
        Span<int> timeline = stackalloc int[10];
        for (int i = 0; i < timeline.Length; i++)
        {
            yield return timeline[i];
        }
    }
    
    // The TARDIS doesn't like it when you try to take pieces of her
    public Span<byte> GetGallifreyanData()
    {
        Span<byte> data = stackalloc byte[256];
        data[0] = 0x42;
        return data;
    }
    
    public void ActivateSafetyProtocols()
    {
        Span<int> protocols = stackalloc int[5];
        Action printProtocol = () => Console.WriteLine(protocols[0]);
        printProtocol();
    }
}
