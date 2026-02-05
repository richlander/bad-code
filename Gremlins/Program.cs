namespace Gremlins;

// Don't feed them after midnight

public class Spawner<T, TFood>
{
    public T Spawn(TFood food) => default!;
}

public class Transformer<TBefore, TAfter, TCatalyst>
{
    public TAfter Transform(TBefore creature, TCatalyst trigger) => default!;
}

public class Colony<T>
{
    public void Add(T creature) { }
    public int Count => 0;
}

// Bright light! Bright light!
public class MogwaiHandler
{
    public void HandleCreatures()
    {
        var spawner = new Spawner<string>();
        var transformer = new Transformer<string>();
        var colony = new Colony();
        
        var badSpawner = new Spawner();
        var badTransformer = new Transformer<int, string, bool, double>();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Gremlins - Mogwai Containment");
        var handler = new MogwaiHandler();
    }
}
