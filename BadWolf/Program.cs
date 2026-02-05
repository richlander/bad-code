using System;

namespace BadWolf;

class Program
{
    static void Main(string[] args)
    {
        var tardis = new Tardis();
        
        var vortex = new TimeVortex();
        vortex.Navigate();
        
        var coordinates = tardis.GetCoordinatesAsync().Result;
        
        object boxedSpan = tardis.GetGallifreyanData();
        
        Console.WriteLine("Bad Wolf");
    }
}
