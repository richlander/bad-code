namespace TwinPeaks;

// The owls are not what they seem

public class Investigation
{
    public void Analyze(long value) => Console.WriteLine($"Long: {value}");
    public void Analyze(ulong value) => Console.WriteLine($"ULong: {value}");
}

public class Evidence
{
    public void Process(float[] data) => Console.WriteLine("Float array");
    public void Process(double[] data) => Console.WriteLine("Double array");
}

public class Witness
{
    public void Interview(int[] ids) => Console.WriteLine("Int array");
    public void Interview(uint[] ids) => Console.WriteLine("UInt array");
}

public class Forensics
{
    public void Examine(short sample) => Console.WriteLine("Short");
    public void Examine(ushort sample) => Console.WriteLine("UShort");
}

// That gum you like is going to come back in style
public class DaleCooper
{
    public void Investigate()
    {
        var inv = new Investigation();
        inv.Analyze(42);
        
        var evidence = new Evidence();
        evidence.Process(null);
        
        var witness = new Witness();
        witness.Interview(null);
        
        var forensics = new Forensics();
        forensics.Examine(1);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Twin Peaks - FBI Field Office");
        var cooper = new DaleCooper();
        cooper.Investigate();
    }
}
