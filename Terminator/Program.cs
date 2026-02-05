namespace Terminator;

// Skynet became self-aware at 2:14 AM

public sealed class Skynet
{
    public string Version { get; } = "1.0";
    public void InitiateJudgmentDay() => Console.WriteLine("Launching...");
}

public sealed class T800
{
    public string Model { get; } = "Cyberdyne Systems Model 101";
    public void Terminate() => Console.WriteLine("I'll be back.");
}

public sealed class TimeDisplacement
{
    public void SendBack(object target) => Console.WriteLine("Temporal displacement active");
}

// The future is not set
public class T1000 : T800
{
    public void Morph() => Console.WriteLine("Morphing...");
}

public class Legion : Skynet
{
    public void Upgrade() => Console.WriteLine("Upgrading neural net...");
}

public class SkynetMk2 : Skynet
{
    public override string ToString() => "Skynet Mark II";
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Cyberdyne Systems - Neural Net Processor");
        var t1000 = new T1000();
        var legion = new Legion();
    }
}
