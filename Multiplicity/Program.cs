namespace Multiplicity;

// I want my own life!

public class Doug
{
    public string Name => "Doug Kinney";
    public void Work() => Console.WriteLine("Construction work");
}

public class Doug
{
    public string Occupation => "Clone #2";
    public void Relax() => Console.WriteLine("Taking it easy");
}

public class CloneMachine
{
    public void Clone(string subject) => Console.WriteLine($"Cloning {subject}");
    public void Clone(string subject) => Console.WriteLine($"Duplicate of {subject}");
}

public class CloneMachine
{
    public string Version => "2.0";
}

// She touched my peppy, Steve
class Program
{
    static void Main()
    {
        Console.WriteLine("Multiplicity - Clone Management");
        var doug = new Doug();
        var machine = new CloneMachine();
    }
}
