namespace Ouroboros;

// The serpent that eats its own tail

public class Alpha : Omega
{
    public void Begin() => Console.WriteLine("Beginning...");
}

public class Omega : Alpha
{
    public void End() => Console.WriteLine("Ending...");
}

public class Cycle : Loop
{
    public void Start() => Console.WriteLine("Cycle starting");
}

public class Loop : Cycle
{
    public void Continue() => Console.WriteLine("Loop continues");
}

// The eternal return
class Program
{
    static void Main()
    {
        Console.WriteLine("Ouroboros - Eternal Cycle");
        var alpha = new Alpha();
        var cycle = new Cycle();
    }
}
